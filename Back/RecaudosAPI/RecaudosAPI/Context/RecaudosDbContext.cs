using Microsoft.EntityFrameworkCore;
using RecaudosAPI.Models;

namespace RecaudosAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recaudos> Recaudo { get; set; }
        public DbSet<Reportes> Reporte { get; set; }
        public DbSet<Totales> Total { get; set; }
        public DbSet<Estaciones> Estacione { get; set; }
        public DbSet<Fechas> Fecha { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
    }
}
