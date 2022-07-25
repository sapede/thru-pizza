using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        public Tamanho Tamanho { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public int Quantidade { get; set; }

        public Receita Receita { get; set; }

        [NotMapped]
        public int ValorCalculado { get; set; }
    }
}
