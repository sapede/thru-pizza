namespace WebApi.Models.Pedidos;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class PedidoCreateRequest
{
    [Required]
    public decimal ValorTotal { get; set; }

    [Required]
    public DateTime DataPedido { get; set; }

    [Required]
    [EnumDataType(typeof(StatusPedido))]
    public string StatusPedido { get; set; }

    [Required]
    [EnumDataType(typeof(MetodoPagamento))]
    public string MetodoPagamento { get; set; }

    public decimal? ValorPagamento { get; set; }

}