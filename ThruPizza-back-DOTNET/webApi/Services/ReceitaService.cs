namespace WebApi.Services;

using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Receitas;

public interface IReceitaService
{
    IEnumerable<ReceitaResponse> GetAll();
    ReceitaResponse GetById(int id);
    ReceitaResponse Create(ReceitaCreateRequest model);
    ReceitaResponse Update(int id, ReceitaUpdateRequest model);
    void Delete(int id);
}

public class ReceitaService : IReceitaService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public ReceitaService(
        DataContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<ReceitaResponse> GetAll()
    {
        var receitas = _context.Receitas;
        return _mapper.Map<IList<ReceitaResponse>>(receitas);
    }

    public ReceitaResponse GetById(int id)
    {
        var receita = getReceita(id);
        return _mapper.Map<ReceitaResponse>(receita);
    }

    public ReceitaResponse Create(ReceitaCreateRequest model)
    {
        // map model to new Receita object
        var receita = _mapper.Map<Receita>(model);

        // save Receita
        _context.Receitas.Add(receita);
        _context.SaveChanges();

        return _mapper.Map<ReceitaResponse>(receita);
    }

    public ReceitaResponse Update(int id, ReceitaUpdateRequest model)
    {
        var receita = getReceita(id);

        // copy model to Receita and save
        _mapper.Map(model, receita);
        _context.Receitas.Update(receita);
        _context.SaveChanges();

        return _mapper.Map<ReceitaResponse>(receita);
    }

    public void Delete(int id)
    {
        var Receita = getReceita(id);
        _context.Receitas.Remove(Receita);
        _context.SaveChanges();
    }

    // helper methods

    private Receita getReceita(int id)
    {
        var Receita = _context.Receitas.Find(id);
        if (Receita == null) throw new KeyNotFoundException("Receita not found");
        return Receita;
    }

}