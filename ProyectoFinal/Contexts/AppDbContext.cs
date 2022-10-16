using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Factura> Factura { get; set; }

    }
}
