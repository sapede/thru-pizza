namespace WebApi.Models.Clientes;

using System.Text.Json.Serialization;

public class AuthenticateResponse
{
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public string JwtToken { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }
}