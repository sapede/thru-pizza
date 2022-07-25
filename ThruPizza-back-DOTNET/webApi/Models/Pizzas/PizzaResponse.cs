using WebApi.Entities;

namespace WebApi.Models.Pizzas;

public class PizzaResponse
{
    public int PizzaId { get; set; }

    public string Tamanho { get; set; }

    public int PedidoId { get; set; }

    public int Quantidade { get; set; }

    public int ValorCalculado { get; set; }
}