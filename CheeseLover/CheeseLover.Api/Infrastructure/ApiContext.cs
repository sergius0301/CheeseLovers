using CheeseLover.Shared.Enums;
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

        public ApiContext()
        {
            Seed();
        }

        private void Seed()
        {
            this.Cheeses.AddRange(new Cheese
            {
                Id = 1,
                Category = CheeseType.SemiSoft,
                CheeseColor = CheeseColor.Yellow,
                Price = 12,
                Name = "Gouda Semi-Soft",
                Description = "Some good cheese 1",
                PictureUrl = "https://www.onlygfx.com/wp-content/uploads/2021/01/cartoon-cheese-1.png"
            },
              new Cheese
              {
                  Id = 2,
                  Category = CheeseType.HardGrating,
                  CheeseColor = CheeseColor.Yellow,
                  Price = 24,
                  Name = "Hard Grating",
                  Description = "Some good cheese 2",
                  PictureUrl = "https://www.onlygfx.com/wp-content/uploads/2021/01/cartoon-cheese-1.png"
              },
              new Cheese
              {
                  Id = 3,
                  Category = CheeseType.Unripened,
                  CheeseColor = CheeseColor.Yellow,
                  Price = 8,
                  Name = "Unripened",
                  Description = "Some good cheese 3",
                  PictureUrl = "https://www.onlygfx.com/wp-content/uploads/2021/01/cartoon-cheese-1.png"
              },
              new Cheese
              {
                  Id = 4,
                  Category = CheeseType.GoatCheese,
                  CheeseColor = CheeseColor.White,
                  Price = 6,
                  Name = "Goat Cheese",
                  Description = "Some good cheese 4",
                  PictureUrl = "https://www.onlygfx.com/wp-content/uploads/2021/01/cartoon-cheese-1.png"
              },
              new Cheese
              {
                  Id = 5,
                  Category = CheeseType.BlueVeined,
                  CheeseColor = CheeseColor.Blue,
                  Price = 9,
                  Name = "Blue Veined",
                  Description = "Some good cheese 5",
                  PictureUrl = "https://www.onlygfx.com/wp-content/uploads/2021/01/cartoon-cheese-1.png"
              });
            this.SaveChanges();
        }

        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
