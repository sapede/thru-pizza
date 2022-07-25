namespace WebApi.Models.Receitas;

using System.ComponentModel.DataAnnotations;

public class ReceitaCreateRequest
{
    [Required]
    public int PizzaId { get; set; }
}