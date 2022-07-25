using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public MetodoPagamento? MetodoPagamento { get; set; }
        public decimal? ValorPagamento { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
    }
}
