using Microsoft.EntityFrameworkCore;
using SistemaEventosSonart.Models;

namespace SistemaEventosSonart.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<SolicitudEvento> SolicitudesEvento { get; set; }

        public DbSet<PaqueteServicio> PaquetesServicio { get; set; }

        public DbSet<ServicioAdicional> ServiciosAdicionales { get; set; }

        public DbSet<Cotizacion> Cotizaciones { get; set; }
    }
}