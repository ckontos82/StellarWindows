using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace FetchNASAAPIApp.Controllers
{
    public class NASAController : Controller
    {
        private INasaApiService _nasaApiService;

        public NASAController(INasaApiService nasaApiService)
        {
            _nasaApiService = nasaApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPicture(NasaApiRequestParams nasaApiRequestParams)
        {
            var picturesDto = await _nasaApiService.FetchData(nasaApiRequestParams);
            var pictures = picturesDto.Select(p => new Picture
            {
                Copyright = p.Copyright,
                Date = p.Date,
                Explanation = p.Explanation,
                Hdurl = p.Hdurl,
                Media_type = p.Media_type,
                Service_version = p.Service_version,
                Title = p.Title,
                Url = p.Url
            }).ToList();

            return View(pictures);
        }
    }
}
