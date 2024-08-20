using Menu.Data;
using Menu.Models;
using Menu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class CreateController : Controller
    {
        private readonly ICreateDishService _createDishService;

        public CreateController(ICreateDishService createDishService)
        {
            _createDishService = createDishService;
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
                await _createDishService.CreateDish(dishDTO);
                return RedirectToAction("Index", "Home"); // Redirect to a valid action
            }

            return View(dishDTO); // Return view with errors if model state is invalid
        }
    }
}
