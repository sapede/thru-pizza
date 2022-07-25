using WebApi.Entities;

namespace WebApi.Models.Pedidos;

public class PedidoResponse
{
    public int PedidoId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public MetodoPagamento? MetodoPagamento { get; set; }
    public decimal? ValorPagamento { get; set; }
}