namespace WebApi.Models.Pizzas;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class PizzaCreateRequest
{
    [Required]
    [EnumDataType(typeof(Tamanho))]
    public string Tamanho { get; set; }

    [Required]
    public int PedidoId { get; set; }

    [Required]
    public int Quantidade { get; set; }
}