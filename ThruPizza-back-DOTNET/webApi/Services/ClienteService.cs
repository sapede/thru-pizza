namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Clientes;

public interface IClienteService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
    AuthenticateResponse RefreshToken(string token, string ipAddress);
    void RevokeToken(string token, string ipAddress);
    void Register(ClienteRegisterRequest model, string origin);
    void ValidateResetToken(ValidateResetTokenRequest model);
    void ResetPassword(ResetPasswordRequest model);
    IEnumerable<ClienteResponse> GetAll();
    ClienteResponse GetById(int id);
    ClienteResponse Create(ClienteCreateRequest model);
    ClienteResponse Update(int id, ClienteUpdateRequest model);
    void Delete(int id);
}

public class ClienteService : IClienteService
{
    private readonly DataContext _context;
    private readonly IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public ClienteService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
    {
        var Cliente = _context.Clientes.Include(x => x.RefreshTokens).SingleOrDefault(x => x.Email == model.Email);

        // validate
        if (Cliente == null || !BCrypt.Verify(model.Password, Cliente.PasswordHash))
            throw new AppException("Email or password is incorrect");

        // authentication successful so generate jwt and refresh tokens
        var jwtToken = _jwtUtils.GenerateJwtToken(Cliente);
        var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
        Cliente.RefreshTokens.Add(refreshToken);

        // remove old refresh tokens from Cliente
        removeOldRefreshTokens(Cliente);

        // save changes to db
        _context.Update(Cliente);
        _context.SaveChanges();

        var response = _mapper.Map<AuthenticateResponse>(Cliente);
        response.JwtToken = jwtToken;
        response.RefreshToken = refreshToken.Token;
        return response;
    }

    public AuthenticateResponse RefreshToken(string token, string ipAddress)
    {
        var Cliente = getClienteByRefreshToken(token);
        var refreshToken = Cliente.RefreshTokens.Single(x => x.Token == token);

        if (refreshToken.IsRevoked)
        {
            // revoke all descendant tokens in case this token has been compromised
            revokeDescendantRefreshTokens(refreshToken, Cliente, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
            _context.Update(Cliente);
            _context.SaveChanges();
        }

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // replace old refresh token with a new one (rotate token)
        var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
        Cliente.RefreshTokens.Add(newRefreshToken);

        // remove old refresh tokens from Cliente
        removeOldRefreshTokens(Cliente);

        // save changes to db
        _context.Update(Cliente);
        _context.SaveChanges();

        // generate new jwt
        var jwtToken = _jwtUtils.GenerateJwtToken(Cliente);

        // return data in authenticate response object
        var response = _mapper.Map<AuthenticateResponse>(Cliente);
        response.JwtToken = jwtToken;
        response.RefreshToken = newRefreshToken.Token;
        return response;
    }

    public void RevokeToken(string token, string ipAddress)
    {
        var Cliente = getClienteByRefreshToken(token);
        var refreshToken = Cliente.RefreshTokens.Single(x => x.Token == token);

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // revoke token and save
        revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
        _context.Update(Cliente);
        _context.SaveChanges();
    }

    public void Register(ClienteRegisterRequest model, string origin)
    {
        // validate
        if (_context.Clientes.Any(x => x.Email == model.Email))
        {
            return;
        }

        // map model to new Cliente object
        var Cliente = _mapper.Map<Cliente>(model);

        // first registered Cliente is an admin
        var isFirstCliente = _context.Clientes.Count() == 0;
        Cliente.Role = isFirstCliente ? Role.Admin : Role.User;
        Cliente.Created = DateTime.UtcNow;
        Cliente.VerificationToken = generateVerificationToken();

        // hash password
        Cliente.PasswordHash = BCrypt.HashPassword(model.Password);

        // save Cliente
        _context.Clientes.Add(Cliente);
        _context.SaveChanges();
    }

    public void ValidateResetToken(ValidateResetTokenRequest model)
    {
        getClienteByResetToken(model.Token);
    }

    public void ResetPassword(ResetPasswordRequest model)
    {
        var Cliente = getClienteByResetToken(model.Token);

        // update password and remove reset token
        Cliente.PasswordHash = BCrypt.HashPassword(model.Password);
        Cliente.PasswordReset = DateTime.UtcNow;
        Cliente.ResetToken = null;
        Cliente.ResetTokenExpires = null;

        _context.Clientes.Update(Cliente);
        _context.SaveChanges();
    }

    public IEnumerable<ClienteResponse> GetAll()
    {
        var Clientes = _context.Clientes;
        return _mapper.Map<IList<ClienteResponse>>(Clientes);
    }

    public ClienteResponse GetById(int id)
    {
        var Cliente = getCliente(id);
        return _mapper.Map<ClienteResponse>(Cliente);
    }

    public ClienteResponse Create(ClienteCreateRequest model)
    {
        // validate
        if (_context.Clientes.Any(x => x.Email == model.Email))
            throw new AppException($"Email '{model.Email}' is already registered");

        // map model to new Cliente object
        var Cliente = _mapper.Map<Cliente>(model);
        Cliente.Created = DateTime.UtcNow;

        // hash password
        Cliente.PasswordHash = BCrypt.HashPassword(model.Password);

        // save Cliente
        _context.Clientes.Add(Cliente);
        _context.SaveChanges();

        return _mapper.Map<ClienteResponse>(Cliente);
    }

    public ClienteResponse Update(int id, ClienteUpdateRequest model)
    {
        var Cliente = getCliente(id);

        // validate
        if (Cliente.Email != model.Email && _context.Clientes.Any(x => x.Email == model.Email))
            throw new AppException($"Email '{model.Email}' is already registered");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            Cliente.PasswordHash = BCrypt.HashPassword(model.Password);

        // copy model to Cliente and save
        _mapper.Map(model, Cliente);
        Cliente.Updated = DateTime.UtcNow;
        _context.Clientes.Update(Cliente);
        _context.SaveChanges();

        return _mapper.Map<ClienteResponse>(Cliente);
    }

    public void Delete(int id)
    {
        var Cliente = getCliente(id);
        _context.Clientes.Remove(Cliente);
        _context.SaveChanges();
    }

    // helper methods

    private Cliente getCliente(int id)
    {
        var Cliente = _context.Clientes.Find(id);
        if (Cliente == null) throw new KeyNotFoundException("Cliente not found");
        return Cliente;
    }

    private Cliente getClienteByRefreshToken(string token)
    {
        var Cliente = _context.Clientes.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
        if (Cliente == null) throw new AppException("Invalid token");
        return Cliente;
    }

    private Cliente getClienteByResetToken(string token)
    {
        var Cliente = _context.Clientes.SingleOrDefault(x =>
            x.ResetToken == token && x.ResetTokenExpires > DateTime.UtcNow);
        if (Cliente == null) throw new AppException("Invalid token");
        return Cliente;
    }

    private string generateJwtToken(Cliente Cliente)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", Cliente.ClienteId.ToString()) }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string generateResetToken()
    {
        // token is a cryptographically strong random sequence of values
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        // ensure token is unique by checking against db
        var tokenIsUnique = !_context.Clientes.Any(x => x.ResetToken == token);
        if (!tokenIsUnique)
            return generateResetToken();
        
        return token;
    }

    private string generateVerificationToken()
    {
        // token is a cryptographically strong random sequence of values
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        // ensure token is unique by checking against db
        var tokenIsUnique = !_context.Clientes.Any(x => x.VerificationToken == token);
        if (!tokenIsUnique)
            return generateVerificationToken();
        
        return token;
    }

    private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
    {
        var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
        revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    private void removeOldRefreshTokens(Cliente Cliente)
    {
        _context.RefreshTokens.RemoveRange(
            Cliente.RefreshTokens
            .Where(x => !x.IsActive && x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow)
        );
    }

    private void revokeDescendantRefreshTokens(RefreshToken refreshToken, Cliente Cliente, string ipAddress, string reason)
    {
        // recursively traverse the refresh token chain and ensure all descendants are revoked
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = Cliente.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
            if (childToken.IsActive)
                revokeRefreshToken(childToken, ipAddress, reason);
            else
                revokeDescendantRefreshTokens(childToken, Cliente, ipAddress, reason);
        }
    }

    private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;
        token.ReasonRevoked = reason;
        token.ReplacedByToken = replacedByToken;
    }
}