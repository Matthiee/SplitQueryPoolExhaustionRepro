using Microsoft.EntityFrameworkCore;
using SplitQueryPoolExhaustionRepro.Entities;

namespace SplitQueryPoolExhaustionRepro
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzaDbContext db;

        public PizzaService(PizzaDbContext db)
        {
            this.db = db;
        }

        public async Task<PizzaDto> GetPizzaAsync(int id)
        {
            var pizza = await db.Pizzas
                .Where(p => p.Id == id)
                .Include(p => p.Ingredients
                            .Where(i => i.Price > 2))
                .AsNoTracking()
                .FirstAsync();

            var dto = new PizzaDto
            {
                Id = pizza.Id,
                Name = pizza.Name
            };

            foreach (var ingredient in pizza.Ingredients)
            {
                dto.Ingredients.Add(new IngredientDto { Id = ingredient.Id, Name = ingredient.Name, Price = ingredient.Price });
            }

            return dto;
        }
    }

    public interface IPizzaService
    {
        Task<PizzaDto> GetPizzaAsync(int id);
    }

    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }

    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
