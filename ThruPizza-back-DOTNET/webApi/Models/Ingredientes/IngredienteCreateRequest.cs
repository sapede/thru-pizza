namespace WebApi.Models.Ingredientes;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class IngredienteCreateRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public float QuantidadePadrao { get; set; }

    [Required]
    public decimal PrecoPorQuantidade { get; set; }
}