namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Pedidos;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PedidoController : BaseController
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<PedidoResponse>> GetAll()
    {
        var pedido = _pedidoService.GetAll();
        return Ok(pedido);
    }

    [HttpGet("{id:int}")]
    public ActionResult<PedidoResponse> GetById(int id)
    {
        var pedido = _pedidoService.GetById(id);
        return Ok(pedido);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public ActionResult<PedidoResponse> Create(PedidoCreateRequest model)
    {
        var pedido = _pedidoService.Create(model);
        return Ok(pedido);
    }

    [HttpPut("{id:int}")]
    public ActionResult<PedidoResponse> Update(int id, PedidoUpdateRequest model)
    {
        var pedido = _pedidoService.Update(id, model);
        return Ok(pedido);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _pedidoService.Delete(id);
        return Ok(new { message = "Pedido deleted successfully" });
    }
}