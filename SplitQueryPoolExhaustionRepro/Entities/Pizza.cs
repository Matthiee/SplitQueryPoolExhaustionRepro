namespace SplitQueryPoolExhaustionRepro.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } 

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
