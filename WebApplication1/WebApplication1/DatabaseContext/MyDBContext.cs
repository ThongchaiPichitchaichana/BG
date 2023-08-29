using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.DatabaseContext
{
    public class MyDBContext : DbContext
    {
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BG");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Region> regions { get; set; }
        public DbSet<City> cities { get; set; }

    }

}
