namespace WebApi.Models.Funcionarios;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class FuncionarioCreateRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Telefone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public decimal Salario { get; set; }

    [Required]
    [EnumDataType(typeof(TipoFuncionario))]
    public string TipoFuncionario { get; set; }
}