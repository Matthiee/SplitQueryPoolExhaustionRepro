using Microsoft.EntityFrameworkCore;
using SplitQueryPoolExhaustionRepro.Entities;

namespace SplitQueryPoolExhaustionRepro
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pizza>()
                .HasMany(_ => _.Ingredients)
                .WithOne(_ => _.Pizza)
                .HasForeignKey(_ => _.PizzaId);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita" },
                new Pizza { Id = 2, Name = "Marinara" },
                new Pizza { Id = 3, Name = "Calzone " }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Cheese", PizzaId = 1, Price = 1 },
                new Ingredient { Id = 2, Name = "Tomato", PizzaId = 2, Price = 2 },
                new Ingredient { Id = 3, Name = "Oregano", PizzaId = 3, Price = 3 },
                new Ingredient { Id = 4, Name = "Cheese", PizzaId = 1, Price = 3 },
                new Ingredient { Id = 5, Name = "Tomato", PizzaId = 2, Price = 4 },
                new Ingredient { Id = 6, Name = "Oregano", PizzaId = 3, Price = 5 },
                new Ingredient { Id = 7, Name = "Cheese", PizzaId = 1, Price = 6 },
                new Ingredient { Id = 8, Name = "Tomato", PizzaId = 2, Price = 7 },
                new Ingredient { Id = 9, Name = "Oregano", PizzaId = 3, Price = 8 }
            );
        }
    }
}
