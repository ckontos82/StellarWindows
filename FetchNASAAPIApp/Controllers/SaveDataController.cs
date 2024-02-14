using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp.Controllers
{
    public class SaveDataController : Controller
    {
        private readonly IPictureDAO _pictureDAO;

        public SaveDataController(IPictureDAO pictureDAO)
        {
            _pictureDAO = pictureDAO;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(Picture picture)
        {
            if (ModelState.IsValid)
            {
                await _pictureDAO.CreateEntryAsync(picture);
                return RedirectToAction(nameof(Index), "NASA");
            }

            return View(picture);
        }
    }
}
