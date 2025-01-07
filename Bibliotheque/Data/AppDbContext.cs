using Microsoft.EntityFrameworkCore;
using Bibliotheque.Models;

namespace Bibliotheque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Achat> Achats { get; set; }
    }
}
