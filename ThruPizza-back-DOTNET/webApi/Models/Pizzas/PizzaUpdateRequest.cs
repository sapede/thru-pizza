namespace WebApi.Models.Pizzas;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class PizzaUpdateRequest
{
    public int PizzaId { get; set; }

    [EnumDataType(typeof(Tamanho))]
    public string Tamanho { get; set; }

    public int PedidoId { get; set; }

    public int Quantidade { get; set; }

    public int ValorCalculado { get; set; }
}