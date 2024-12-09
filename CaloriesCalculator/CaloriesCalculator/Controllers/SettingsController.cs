using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//namespace CaloriesCalculator.Controllers
//{
//    [Authorize]
//    public class SettingsController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<IdentityUser> _userManager;

//        public SettingsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var userId = _userManager.GetUserId(User);
//            var settings = await _context.UserSettings.FirstOrDefaultAsync(us => us.UserId == userId);

//            if (settings == null)
//            {
//                settings = new UserSettings { UserId = userId, TargetCalories = 2000, WeeklyTargetCalories = 14000 };
//                _context.UserSettings.Add(settings);
//                await _context.SaveChangesAsync();
//            }

//            return View(settings);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Update(UserSettings model)
//        {
//            var userId = _userManager.GetUserId(User);

//            var settings = await _context.UserSettings.FirstOrDefaultAsync(us => us.UserId == userId);
//            if (settings == null) return NotFound();

//            settings.TargetCalories = model.TargetCalories;
//            settings.WeeklyTargetCalories = model.WeeklyTargetCalories;

//            await _context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }
//    }

//}
