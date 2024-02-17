using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FetchNASAAPIApp.Controllers
{
    public class FetchDbDataController : Controller
    {
        private readonly IPictureDAO pictureDAO;

        public FetchDbDataController(IPictureDAO pictureDAO)
        {
            this.pictureDAO = pictureDAO;
        }

        [HttpGet]
        public async Task<IActionResult> GetPicture(DateOnly date)
        {
            var picture = await pictureDAO.GetPictureByDateAsync(date);
           
            if (picture != null)
            {
                List<Picture> pictures = new List<Picture>();
                pictures.Add(picture);
                return View("/Views/NASA/GetPicture.cshtml", pictures);
            }
                
            else return NotFound("No picture found for the selected date.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPicturesAsync()
        {
            var pictures = await pictureDAO.GetAllPicturesAsync();
            return View(pictures);
        }
    }
}
