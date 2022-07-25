namespace WebApi.Models.Clientes;

public class ClienteResponse
{
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}