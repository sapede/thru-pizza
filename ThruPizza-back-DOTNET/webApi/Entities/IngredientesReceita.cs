using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class IngredientesReceita
    {
        [Key]
        public int IngredientesReceitaId { get; set; }

        public int IngredienteId { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public int QuantidadeIngrediente { get; set; }

        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }

    }
}