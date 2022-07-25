namespace WebApi.Services;

using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Funcionarios;

public interface IFuncionarioService
{
    IEnumerable<FuncionarioResponse> GetAll();
    FuncionarioResponse GetById(int id);
    FuncionarioResponse Create(FuncionarioCreateRequest model);
    FuncionarioResponse Update(int id, FuncionarioUpdateRequest model);
    void Delete(int id);
}

public class FuncionarioService : IFuncionarioService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public FuncionarioService(
        DataContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<FuncionarioResponse> GetAll()
    {
        var funcionarios = _context.Funcionarios;
        return _mapper.Map<IList<FuncionarioResponse>>(funcionarios);
    }

    public FuncionarioResponse GetById(int id)
    {
        var funcionario = getFuncionario(id);
        return _mapper.Map<FuncionarioResponse>(funcionario);
    }

    public FuncionarioResponse Create(FuncionarioCreateRequest model)
    {
        // map model to new Funcionario object
        var funcionario = _mapper.Map<Funcionario>(model);

        // save Funcionario
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();

        return _mapper.Map<FuncionarioResponse>(funcionario);
    }

    public FuncionarioResponse Update(int id, FuncionarioUpdateRequest model)
    {
        var funcionario = getFuncionario(id);

        // copy model to Funcionario and save
        _mapper.Map(model, funcionario);
        _context.Funcionarios.Update(funcionario);
        _context.SaveChanges();

        return _mapper.Map<FuncionarioResponse>(funcionario);
    }

    public void Delete(int id)
    {
        var Funcionario = getFuncionario(id);
        _context.Funcionarios.Remove(Funcionario);
        _context.SaveChanges();
    }

    // helper methods

    private Funcionario getFuncionario(int id)
    {
        var Funcionario = _context.Funcionarios.Find(id);
        if (Funcionario == null) throw new KeyNotFoundException("Funcionario not found");
        return Funcionario;
    }

}