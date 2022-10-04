using CheeseLover.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseLover.Api.Infrastructure
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CheeseDB");
        }
        public DbSet<Cheese> Cheeses { get; set; }
    }
}
