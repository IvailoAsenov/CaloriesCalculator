using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesCalculator.Controllers
{
    [Authorize]
    public class UserProgressController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserProgressController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Извличане на всички калории от базата
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);  // Вземаме UserId на текущия потребител

            // Извличаме всички записи за калориите на текущия потребител
            var progress = await _context.UserProgress
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            // Примерна стойност за целта
            int weeklyGoal = 2000; // Цел за калории, можеш да я вземеш от база или настройка за потребителя

            // Връщаме данните към изгледа
            return View(new UserProgress
            {
                WeeklyGoal = weeklyGoal
            });
        }

        // Добавяне на калории
        [HttpPost]
        public async Task<IActionResult> AddCalories(int calories)
        {
            var userId = _userManager.GetUserId(User);  // Вземаме UserId на текущия потребител
            var today = DateTime.Today;

            // Проверка дали вече има запис за днешния ден
            var existingEntry = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserId == userId && p.Date.Date == today);

            if (existingEntry != null)
            {
                existingEntry.ConsumedCalories += calories;  // Ако има запис, увеличаваме калориите
            }
            else
            {
                var newEntry = new UserProgress
                {
                    UserId = userId,  // Свързваме с потребителя
                    Date = today,
                    ConsumedCalories = calories
                };
                _context.UserProgress.Add(newEntry);  // Добавяме нов запис
            }

            await _context.SaveChangesAsync();  // Записваме промените в базата данни
            return RedirectToAction("Index");  // Пренасочваме към основната страница
        }


        // Премахване на калории
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> RemoveCalories(int id)
        {
            var userId = _userManager.GetUserId(User);  // Вземаме UserId на текущия потребител
            var entry = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);  // Проверка дали записът е на текущия потребител

            if (entry != null)
            {
                _context.UserProgress.Remove(entry);  // Премахваме записа
                await _context.SaveChangesAsync();  // Записваме промените в базата
            }

            return RedirectToAction("Index");  // Пренасочваме към основната страница
        }



    }
}
