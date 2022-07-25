using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        public string Nome { get; set; }

        public float QuantidadePadrao { get; set; }

        public decimal PrecoPorQuantidade { get; set; }

        public ICollection<IngredientesReceita> IngredientesReceitas { get; set; }
    }
}