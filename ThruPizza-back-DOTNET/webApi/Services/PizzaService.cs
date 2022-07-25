namespace WebApi.Services;

using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Pizzas;

public interface IPizzaService
{
    IEnumerable<PizzaResponse> GetAll();
    PizzaResponse GetById(int id);
    PizzaResponse Create(PizzaCreateRequest model);
    PizzaResponse Update(int id, PizzaUpdateRequest model);
    void Delete(int id);
}

public class PizzaService : IPizzaService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public PizzaService(
        DataContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<PizzaResponse> GetAll()
    {
        var pizzas = _context.Pizzas;
        return _mapper.Map<IList<PizzaResponse>>(pizzas);
    }

    public PizzaResponse GetById(int id)
    {
        var pizza = getPizza(id);
        return _mapper.Map<PizzaResponse>(pizza);
    }

    public PizzaResponse Create(PizzaCreateRequest model)
    {
        // map model to new Pizza object
        var pizza = _mapper.Map<Pizza>(model);

        // save Pizza
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();

        return _mapper.Map<PizzaResponse>(pizza);
    }

    public PizzaResponse Update(int id, PizzaUpdateRequest model)
    {
        var pizza = getPizza(id);

        // copy model to Pizza and save
        _mapper.Map(model, pizza);
        _context.Pizzas.Update(pizza);
        _context.SaveChanges();

        return _mapper.Map<PizzaResponse>(pizza);
    }

    public void Delete(int id)
    {
        var Pizza = getPizza(id);
        _context.Pizzas.Remove(Pizza);
        _context.SaveChanges();
    }

    // helper methods

    private Pizza getPizza(int id)
    {
        var Pizza = _context.Pizzas.Find(id);
        if (Pizza == null) throw new KeyNotFoundException("Pizza not found");
        return Pizza;
    }

}