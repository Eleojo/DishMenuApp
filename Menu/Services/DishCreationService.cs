using Menu.Data;
using Menu.Models;

namespace Menu.Services
{
    public class DishCreationService : IDishCreationService
    {
        private readonly MenuDbContext _dbContext;

        public DishCreationService(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateDishAsync(DishDTO dishDTO)
        {
            if (dishDTO == null)
            {
                return false;
            }

            var newDish = MapToDishEntity(dishDTO);

            var ingredientNames = dishDTO.IngredientNames
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(name => name.Trim())
                .ToList();

            await AddIngredientsToDishAsync(newDish, ingredientNames);

            _dbContext.Dishes.Add(newDish);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private Dish MapToDishEntity(DishDTO dishDTO)
        {
            return new Dish
            {
                Id = Guid.NewGuid(),
                Name = dishDTO.Name,
                ImageUrl = dishDTO.ImageUrl,
                Price = dishDTO.Price,
                DishIngredients = new List<DishIngredient>(),
            };
        }

        private async Task AddIngredientsToDishAsync(Dish dish, List<string> ingredientNames)
        {
            foreach (var ingredientName in ingredientNames)
            {
                var existingIngredient = _dbContext.Ingredients.FirstOrDefault(i => i.Name == ingredientName);

                if (existingIngredient != null)
                {
                    // Link the existing ingredient to the dish
                    LinkIngredientToDish(dish, existingIngredient);
                }
                else
                {
                    // Create and link a new ingredient to the dish
                    var newIngredient = new Ingredient
                    {
                        Id = Guid.NewGuid(),
                        Name = ingredientName,
                    };

                    LinkIngredientToDish(dish, newIngredient);

                    _dbContext.Ingredients.Add(newIngredient);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private void LinkIngredientToDish(Dish dish, Ingredient ingredient)
        {
            dish.DishIngredients.Add(new DishIngredient
            {
                DishId = dish.Id,
                IngredientId = ingredient.Id,
            });
        }
    }
}
