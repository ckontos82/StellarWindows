using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp.Controllers
{
    public class SaveDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaveDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Picture picture)
        {
            if (ModelState.IsValid)
            {
                _context.Pictures.Add(picture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "NASA");
            }

            return View(picture);
        }
    }
}
