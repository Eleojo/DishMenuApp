using Menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuDbContext _menuDbContext;

        public MenuController(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _menuDbContext.Dishes select d;

            if(!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
            }
                
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var dish = await _menuDbContext.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(di => di.Id == id);

            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

    }
}
