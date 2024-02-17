using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FetchNASAAPIApp.Controllers
{
    public class FetchDbDataController : Controller
    {
        private readonly IPictureService _pictureService;

        public FetchDbDataController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPicture(DateOnly date)
        {
			ViewData["ShowSaveButton"] = false;
			var picture = await _pictureService.GetPictureByDateAsync(date);
           
            if (picture != null)
            {
                List<Picture> pictures = new List<Picture>();
                pictures.Add(picture);
                return View("/Views/NASA/GetPicture.cshtml", pictures);
            }
                
            else return NotFound("No picture found for the selected date.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPictures()
        {
			ViewData["ShowSaveButton"] = false;
			var pictures = await _pictureService.GetAllPicturesAsync();
            return View(pictures);
        }
    }
}
