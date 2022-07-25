namespace WebApi.Models.Pedidos;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class PedidoUpdateRequest
{
    public decimal ValorTotal { get; set; }

    public DateTime DataPedido { get; set; }

    [EnumDataType(typeof(StatusPedido))]
    public string StatusPedido { get; set; }

    [EnumDataType(typeof(MetodoPagamento))]
    public string MetodoPagamento { get; set; }

    public decimal? ValorPagamento { get; set; }
}