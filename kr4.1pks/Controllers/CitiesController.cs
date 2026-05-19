using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kr4._1pks.Data;
using kr4._1pks.Models;

namespace kr4._1pks.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            ViewData["CurrentSearch"] = search;

            // Загружаем все города из БД в память (их мало, это безопасно)
            var cities = await _context.Cities
                .OrderBy(c => c.Name)
                .ToListAsync();

            // Регистронезависимый поиск по кириллице в памяти
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchTrimmed = search.Trim();
                cities = cities
                    .Where(c => c.Name.Contains(searchTrimmed, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(cities);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var city = await _context.Cities
                .Include(c => c.Attractions)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (city == null)
                return NotFound();

            return View(city);
        }
    }
}