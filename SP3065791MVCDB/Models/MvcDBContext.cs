using Microsoft.EntityFrameworkCore;

namespace SP3065791MVCDB.Models;

public class MvcDBContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Venda> Vendas { get; set; }

    public MvcDBContext(DbContextOptions<MvcDBContext> options) : base(options)
    {

    }
}