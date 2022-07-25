namespace WebApi.Models.Funcionarios;

using WebApi.Entities;
public class FuncionarioResponse
{
    public int FuncionarioId { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public decimal Salario { get; set; }
    public TipoFuncionario TipoFuncionario { get; set; }
}