namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    
    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
}