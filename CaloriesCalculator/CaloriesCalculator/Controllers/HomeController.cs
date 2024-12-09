////using CaloriesCalculator.Models;
////using Microsoft.AspNetCore.Mvc;
////using System.Diagnostics;

////namespace CaloriesCalculator.Controllers
////{
////    public class HomeController : Controller
////    {
////        private readonly ILogger<HomeController> _logger;
////        private readonly ApplicationDbContext data;

////        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _data)
////        {
////            _logger = logger;
////            data = _data;
////        }

////        public IActionResult Index()
////        {
////            return View();
////        }

////        public IActionResult Progres()
////        {
////            var model = 

////            return View();
////        }

////        public IActionResult Sport()
////        {
////            return View();
////        }

////        public IActionResult Food()
////        {
////            return View();
////        }



////        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
////        public IActionResult Error()
////        {
////            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
////        }
////    }
////}


//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using CaloriesCalculator.Models;
//using Microsoft.AspNetCore.Identity;
//using System.Security.Claims;

//namespace CaloriesCalculator.Controllers
//{
//    public class ProgressController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<IdentityUser> _userManager;

//        public ProgressController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        public IActionResult Progres()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            if (userId == null)
//            {
//                return RedirectToAction("Login", "Account");
//            }

//            var progressEntries = _context.ProgressEntries
//                .Where(p => p.UserId == userId)
//                .OrderBy(p => p.Date)
//                .ToList();

//            var weeklyGoal = TempData["WeeklyGoal"] != null ? (int)TempData["WeeklyGoal"] : 14000; // Примерна цел

//            ViewBag.WeeklyGoal = weeklyGoal;
//            ViewBag.TotalCalories = progressEntries.Sum(e => e.Calories);
//            return View(progressEntries);
//        }

//        [HttpPost]
//        public IActionResult UpdateGoal(int weeklyGoal)
//        {
//            if (weeklyGoal <= 0)
//            {
//                ModelState.AddModelError("", "Целта трябва да бъде положително число.");
//                return RedirectToAction(nameof(Progres));
//            }

//            TempData["WeeklyGoal"] = weeklyGoal;
//            return RedirectToAction(nameof(Progres));
//        }

//        [HttpPost]
//        public IActionResult AddCalories(DateTime date, int calories)
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            if (userId == null)
//            {
//                return RedirectToAction("Login", "Account");
//            }

//            if (calories <= 0)
//            {
//                ModelState.AddModelError("", "Калориите трябва да бъдат положително число.");
//                return RedirectToAction(nameof(Progres));
//            }

//            var entry = _context.ProgressEntries.FirstOrDefault(p => p.Date == date && p.UserId == userId);

//            if (entry == null)
//            {
//                entry = new ProgressEntry
//                {
//                    UserId = userId,
//                    Date = date,
//                    Calories = calories
//                };
//                _context.ProgressEntries.Add(entry);
//            }
//            else
//            {
//                entry.Calories += calories;
//            }

//            _context.SaveChanges();
//            return RedirectToAction(nameof(Progres));
//        }
//    }
//}
