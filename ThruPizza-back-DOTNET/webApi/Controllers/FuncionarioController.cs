namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Funcionarios;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FuncionarioController : BaseController
{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<FuncionarioResponse>> GetAll()
    {
        var Funcionario = _funcionarioService.GetAll();
        return Ok(Funcionario);
    }

    [HttpGet("{id:int}")]
    public ActionResult<FuncionarioResponse> GetById(int id)
    {
        var funcionario = _funcionarioService.GetById(id);
        return Ok(funcionario);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public ActionResult<FuncionarioResponse> Create(FuncionarioCreateRequest model)
    {
        var funcionario = _funcionarioService.Create(model);
        return Ok(funcionario);
    }

    [HttpPut("{id:int}")]
    public ActionResult<FuncionarioResponse> Update(int id, FuncionarioUpdateRequest model)
    {

        var funcionario = _funcionarioService.Update(id, model);
        return Ok(funcionario);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _funcionarioService.Delete(id);
        return Ok(new { message = "Funcionario deleted successfully" });
    }
}