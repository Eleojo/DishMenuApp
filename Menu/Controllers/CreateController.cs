using Menu.Data;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class CreateController : Controller
    {
        private readonly MenuDbContext _context;

        public CreateController(MenuDbContext context)
        {
            _context = context;
        }

        // GET: Dish/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DishDTO dishDTO)
        {
            if (ModelState.IsValid)
            {
                var dish = new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = dishDTO.Name,
                    ImageUrl = dishDTO.ImageUrl,
                    Price = dishDTO.Price,
                    DishIngredients = new List<DishIngredient>()
                };

                // Split the comma-separated ingredients and trim whitespace
                var ingredientNames = dishDTO.IngredientNames
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .ToList();

                foreach (var ingredientName in ingredientNames)
                {
                    // Check if the ingredient exists
                    var existingIngredient = await _context.Ingredients
                        .FirstOrDefaultAsync(i => i.Name == ingredientName);

                    if (existingIngredient != null)
                    {
                        // Add existing ingredient to dish
                        dish.DishIngredients.Add(new DishIngredient
                        {
                            DishId = dish.Id,
                            IngredientId = existingIngredient.Id
                        });
                    }
                    else
                    {
                        // Create new ingredient
                        var newIngredient = new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            Name = ingredientName
                        };
                        _context.Ingredients.Add(newIngredient);
                        await _context.SaveChangesAsync(); // Save to get the ID

                        // Add new ingredient to dish
                        dish.DishIngredients.Add(new DishIngredient
                        {
                            DishId = dish.Id,
                            IngredientId = newIngredient.Id
                        });
                    }
                }

                // Add the new dish
                _context.Dishes.Add(dish);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); // Redirect to a valid action
            }

            return View(dishDTO); // Return view with errors if model state is invalid
        }
    }
}
