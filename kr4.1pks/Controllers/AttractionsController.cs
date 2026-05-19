using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kr4._1pks.Data;

namespace kr4._1pks.Controllers
{
    public class AttractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var attraction = await _context.Attractions
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (attraction == null) return NotFound();
            return View(attraction);
        }
    }
}