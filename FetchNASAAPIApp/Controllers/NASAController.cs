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
            var pictures = await _nasaApiService.FetchData(nasaApiRequestParams);

            return View(pictures);
        }
    }
}
