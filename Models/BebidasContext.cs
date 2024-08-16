using Microsoft.EntityFrameworkCore;

public class BebidasContext : DbContext
{
    public DbSet<Bebida> Bebidas { get; set; }
    public DbSet<TipoDeBebida> TiposDeBebida { get; set; }

    public BebidasContext(DbContextOptions<BebidasContext> options)
        : base(options)
    {
    }
}

