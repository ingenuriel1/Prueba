using Microsoft.EntityFrameworkCore;
using RecaudosAPI.Models;

namespace RecaudosAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recaudos> Recaudo { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
    }
}
