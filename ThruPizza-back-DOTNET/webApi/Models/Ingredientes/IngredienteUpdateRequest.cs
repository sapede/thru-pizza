namespace WebApi.Models.Ingredientes;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class IngredienteUpdateRequest
{
    public string Nome { get; set; }

    public float QuantidadePadrao { get; set; }

    public decimal PrecoPorQuantidade { get; set; }
}