namespace WebApi.Models.Clientes;

using System.ComponentModel.DataAnnotations;

public class ValidateResetTokenRequest
{
    [Required]
    public string Token { get; set; }
}