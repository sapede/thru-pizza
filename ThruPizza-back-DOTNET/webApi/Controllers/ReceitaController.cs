namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Receitas;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ReceitaController : BaseController
{
    private readonly IReceitaService _receitaService;

    public ReceitaController(IReceitaService receitaService)
    {
        _receitaService = receitaService;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<ReceitaResponse>> GetAll()
    {
        var receita = _receitaService.GetAll();
        return Ok(receita);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReceitaResponse> GetById(int id)
    {
        var receita = _receitaService.GetById(id);
        return Ok(receita);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public ActionResult<ReceitaResponse> Create(ReceitaCreateRequest model)
    {
        var receita = _receitaService.Create(model);
        return Ok(receita);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ReceitaResponse> Update(int id, ReceitaUpdateRequest model)
    {
        var receita = _receitaService.Update(id, model);
        return Ok(receita);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _receitaService.Delete(id);
        return Ok(new { message = "Receita deleted successfully" });
    }
}