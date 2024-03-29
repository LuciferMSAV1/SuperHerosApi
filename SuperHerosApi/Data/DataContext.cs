using Microsoft.EntityFrameworkCore;

namespace SuperHerosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comics> Comics { get; set; }
    }
}
