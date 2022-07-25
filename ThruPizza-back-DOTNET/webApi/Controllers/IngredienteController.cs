namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ingredientes;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class IngredienteController : BaseController
{
    private readonly IIngredienteService _ingredienteService;

    public IngredienteController(IIngredienteService ingredienteService)
    {
        _ingredienteService = ingredienteService;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<IngredienteResponse>> GetAll()
    {
        var Ingrediente = _ingredienteService.GetAll();
        return Ok(Ingrediente);
    }

    [HttpGet("{id:int}")]
    public ActionResult<IngredienteResponse> GetById(int id)
    {
        var ingrediente = _ingredienteService.GetById(id);
        return Ok(ingrediente);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public ActionResult<IngredienteResponse> Create(IngredienteCreateRequest model)
    {
        var ingrediente = _ingredienteService.Create(model);
        return Ok(ingrediente);
    }

    [HttpPut("{id:int}")]
    public ActionResult<IngredienteResponse> Update(int id, IngredienteUpdateRequest model)
    {
        var ingrediente = _ingredienteService.Update(id, model);
        return Ok(ingrediente);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _ingredienteService.Delete(id);
        return Ok(new { message = "Ingrediente deleted successfully" });
    }
}