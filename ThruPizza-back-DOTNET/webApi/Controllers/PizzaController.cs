namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Pizzas;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PizzaController : BaseController
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<PizzaResponse>> GetAll()
    {
        var Pizza = _pizzaService.GetAll();
        return Ok(Pizza);
    }

    [HttpGet("{id:int}")]
    public ActionResult<PizzaResponse> GetById(int id)
    {
        var pizza = _pizzaService.GetById(id);
        return Ok(pizza);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public ActionResult<PizzaResponse> Create(PizzaCreateRequest model)
    {
        var pizza = _pizzaService.Create(model);
        return Ok(pizza);
    }

    [HttpPut("{id:int}")]
    public ActionResult<PizzaResponse> Update(int id, PizzaUpdateRequest model)
    {
        var pizza = _pizzaService.Update(id, model);
        return Ok(pizza);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _pizzaService.Delete(id);
        return Ok(new { message = "Pizza deleted successfully" });
    }
}