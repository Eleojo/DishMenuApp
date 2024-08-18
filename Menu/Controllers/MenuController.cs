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

        public async Task<IActionResult> Index()
        {
            return View(await _menuDbContext.Dishes.ToListAsync());
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
