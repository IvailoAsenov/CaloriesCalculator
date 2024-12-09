using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaloriesCalculator.Controllers
{
    [Authorize]
    public class FoodProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var foodProducts = await _context.FoodProducts.ToListAsync();
            return View(foodProducts);
        }
    }

}
