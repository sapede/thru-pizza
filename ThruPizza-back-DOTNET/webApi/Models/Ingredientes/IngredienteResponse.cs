namespace WebApi.Models.Ingredientes;

public class IngredienteResponse
{
    public int IngredienteId { get; set; }

    public string Nome { get; set; }

    public float QuantidadePadrao { get; set; }

    public decimal PrecoPorQuantidade { get; set; }
}