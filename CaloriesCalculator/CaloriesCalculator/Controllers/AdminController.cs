using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaloriesCalculator.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var foodProducts = await _context.FoodProducts.ToListAsync();
            return View(foodProducts);
        }

        public IActionResult CreateFood()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(FoodProduct food)
        {
            if (ModelState.IsValid)
            {
                _context.FoodProducts.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(food);
        }
    }
}
