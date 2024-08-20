using Menu.Data;
using Menu.Models;

namespace Menu.Services
{
    public class CreateDishService : ICreateDishService
    {
        private readonly MenuDbContext _context;

        public CreateDishService(MenuDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDish(DishDTO dishDTO)
        {
            if (dishDTO == null)
            {
                return false;
            }

            var dish = CreateNewDish(dishDTO);

            var ingredientNames = dishDTO.IngredientNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

            AddIngredientToDish(dish, ingredientNames);

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return true;

        }

        public Dish CreateNewDish(DishDTO dishDTO)
        {
            var dish = new Dish
            {
                Id = Guid.NewGuid(),
                Name = dishDTO.Name,
                ImageUrl = dishDTO.ImageUrl,
                Price = dishDTO.Price,
                DishIngredients = new List<DishIngredient>(),
            };
            return dish;
        }

        public async Task AddIngredientToDish(Dish dish, List<string> ingredientNames)
        {
            foreach (var ingredientName in ingredientNames)
            {
                var existingIngredient = _context.Ingredients.FirstOrDefault(i => i.Name == ingredientName);


                if (existingIngredient != null)
                {
                    AddDishIngredientToDish(dish, existingIngredient);
                }

                //if ingredient doesnt exist create new ingredient and add to dish
                var newIngredient = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = ingredientName,
                    //DishIngredients = new List<DishIngredient>()
                };

                AddDishIngredientToDish(dish, newIngredient);

                _context.Ingredients.Add(newIngredient);
                await _context.SaveChangesAsync();

            }

        }

        public void AddDishIngredientToDish(Dish dish, Ingredient ingredient)
        {
            dish.DishIngredients.Add(new DishIngredient
            {
                DishId = dish.Id,
                IngredientId = ingredient.Id,
            });
        }
    }
}
