namespace WebApi.Models.Funcionarios;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class FuncionarioUpdateRequest
{

    public string Nome { get; set; }

    public string Telefone { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Endereco { get; set; }

    public decimal Salario { get; set; }

    [EnumDataType(typeof(TipoFuncionario))]
    public string TipoFuncionario { get; set; }
}