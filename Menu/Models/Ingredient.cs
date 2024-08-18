namespace Menu.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DishIngredient>? DishIngredients { get; set; }

    }
}
