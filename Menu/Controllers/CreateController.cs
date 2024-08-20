using Menu.Data;
using Menu.Models;
using Menu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class CreateController : Controller
    {
        private readonly IDishCreationService _createDishService;

        public CreateController(IDishCreationService createDishService)
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
            if (dishDTO == null)
            {
                return BadRequest("Dish data is null.");
            }

            if (!ModelState.IsValid)
            {
                return View(dishDTO); 
            }

            var dishCreated = await _createDishService.CreateDishAsync(dishDTO);

            if (dishCreated)
            {
                return RedirectToAction("Index", "Home"); 
            }

            return BadRequest("Failed to create the dish. Please try again."); 
        }
    }
}
