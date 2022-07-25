namespace WebApi.Services;

using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Ingredientes;

public interface IIngredienteService
{
    IEnumerable<IngredienteResponse> GetAll();
    IngredienteResponse GetById(int id);
    IngredienteResponse Create(IngredienteCreateRequest model);
    IngredienteResponse Update(int id, IngredienteUpdateRequest model);
    void Delete(int id);
}

public class IngredienteService : IIngredienteService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public IngredienteService(
        DataContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<IngredienteResponse> GetAll()
    {
        var ingredientes = _context.Ingredientes;
        return _mapper.Map<IList<IngredienteResponse>>(ingredientes);
    }

    public IngredienteResponse GetById(int id)
    {
        var ingrediente = getIngrediente(id);
        return _mapper.Map<IngredienteResponse>(ingrediente);
    }

    public IngredienteResponse Create(IngredienteCreateRequest model)
    {
        // map model to new Ingrediente object
        var ingrediente = _mapper.Map<Ingrediente>(model);

        // save Ingrediente
        _context.Ingredientes.Add(ingrediente);
        _context.SaveChanges();

        return _mapper.Map<IngredienteResponse>(ingrediente);
    }

    public IngredienteResponse Update(int id, IngredienteUpdateRequest model)
    {
        var ingrediente = getIngrediente(id);

        // copy model to Ingrediente and save
        _mapper.Map(model, ingrediente);
        _context.Ingredientes.Update(ingrediente);
        _context.SaveChanges();

        return _mapper.Map<IngredienteResponse>(ingrediente);
    }

    public void Delete(int id)
    {
        var Ingrediente = getIngrediente(id);
        _context.Ingredientes.Remove(Ingrediente);
        _context.SaveChanges();
    }

    // helper methods

    private Ingrediente getIngrediente(int id)
    {
        var Ingrediente = _context.Ingredientes.Find(id);
        if (Ingrediente == null) throw new KeyNotFoundException("Ingrediente not found");
        return Ingrediente;
    }

}