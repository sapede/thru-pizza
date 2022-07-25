namespace WebApi.Services;

using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Pedidos;

public interface IPedidoService
{
    IEnumerable<PedidoResponse> GetAll();
    PedidoResponse GetById(int id);
    PedidoResponse Create(PedidoCreateRequest model);
    PedidoResponse Update(int id, PedidoUpdateRequest model);
    void Delete(int id);
}

public class PedidoService : IPedidoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public PedidoService(
        DataContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<PedidoResponse> GetAll()
    {
        var pedidos = _context.Pedidos;
        return _mapper.Map<IList<PedidoResponse>>(pedidos);
    }

    public PedidoResponse GetById(int id)
    {
        var pedido = getPedido(id);
        return _mapper.Map<PedidoResponse>(pedido);
    }

    public PedidoResponse Create(PedidoCreateRequest model)
    {
        // map model to new Pedido object
        var pedido = _mapper.Map<Pedido>(model);

        // save Pedido
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        return _mapper.Map<PedidoResponse>(pedido);
    }

    public PedidoResponse Update(int id, PedidoUpdateRequest model)
    {
        var pedido = getPedido(id);

        // copy model to Pedido and save
        _mapper.Map(model, pedido);
        _context.Pedidos.Update(pedido);
        _context.SaveChanges();

        return _mapper.Map<PedidoResponse>(pedido);
    }

    public void Delete(int id)
    {
        var Pedido = getPedido(id);
        _context.Pedidos.Remove(Pedido);
        _context.SaveChanges();
    }

    // helper methods

    private Pedido getPedido(int id)
    {
        var Pedido = _context.Pedidos.Find(id);
        if (Pedido == null) throw new KeyNotFoundException("Pedido not found");
        return Pedido;
    }

}