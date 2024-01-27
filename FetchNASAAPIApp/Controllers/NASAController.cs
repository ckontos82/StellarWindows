using FetchNASAAPIApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace FetchNASAAPIApp.Controllers
{
    public class NASAController : Controller
    {
        private HttpClient _client;
        private string _baseUrl = "https://api.nasa.gov/planetary/apod?";

        public NASAController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FetchDataFromAPI(NasaApiRequestParams nasaApiRequestParams)
        {
            var requestParams = new List<string>();

            foreach (var prop in nasaApiRequestParams.GetType().GetProperties())
            {
                var value = prop.GetValue(nasaApiRequestParams);

                if (value is DateOnly dateValue && dateValue != DateOnly.MinValue)
                {
                    requestParams.Add($"{prop.Name.ToLower()}={dateValue:yyyy-MM-dd}");
                }
                else if (value is bool)
                {
                    requestParams.Add($"{prop.Name.ToLower()}={value.ToString().ToLower()}");
                }
                else if (value is int intValue && intValue > 0) 
                {
                    requestParams.Add($"{prop.Name.ToLower()}={intValue}");
                }
            }

            requestParams.Add($"api_key={nasaApiRequestParams.ApiKey}");

            string queryString = string.Join("&", requestParams);
            string url = $"{_baseUrl}{queryString}";

            try
            {

                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var nasaResponse = new List<Picture>();

                var token = JToken.Parse(responseContent);
                if (token.Type == JTokenType.Array)
                {
                    nasaResponse = JsonConvert.DeserializeObject<List<Picture>>(responseContent);
                }
                else if (token.Type == JTokenType.Object)
                {
                    var singleNasaResponse = token.ToObject<Picture>();
                    if (singleNasaResponse != null)
                    {
                        nasaResponse.Add(singleNasaResponse);
                    }
                }

                return View(nasaResponse);
            }
            catch (HttpRequestException httpRequestException)
            {
                return View("Error");
            }
        }      
    }
}
