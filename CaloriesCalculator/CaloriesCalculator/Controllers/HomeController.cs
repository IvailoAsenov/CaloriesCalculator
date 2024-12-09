using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaloriesCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext data;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _data)
        {
            _logger = logger;
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Progres()
        {
            var model = 

            return View();
        }

        public IActionResult Sport()
        {
            return View();
        }

        public IActionResult Food()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
