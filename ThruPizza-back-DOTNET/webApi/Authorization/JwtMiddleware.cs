namespace WebApi.Authorization;

using Microsoft.Extensions.Options;
using WebApi.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, DataContext dataContext, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var clienteId = jwtUtils.ValidateJwtToken(token);
        if (clienteId != null)
        {
            // attach account to context on successful jwt validation
            context.Items["Cliente"] = await dataContext.Clientes.FindAsync(clienteId.Value);
        }

        await _next(context);
    }
}