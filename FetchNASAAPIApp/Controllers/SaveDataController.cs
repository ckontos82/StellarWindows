using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp.Controllers
{
    public class SaveDataController : Controller
    {
        private readonly IPictureService _pictureService;

        public SaveDataController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(Picture picture)
        {
            if (ModelState.IsValid)
            {
                var (isSuccess, message) = await _pictureService.CreateEntryAsync(picture);
                TempData["Message"] = message;
            }

			return RedirectToAction("GetPicture", "NASA");
		}
    }
}
