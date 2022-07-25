using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Receita
    {
        [Key]
        public int ReceitaId { get; set; }

        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public ICollection<IngredientesReceita> IngredientesReceita { get; set; }
    }
}
