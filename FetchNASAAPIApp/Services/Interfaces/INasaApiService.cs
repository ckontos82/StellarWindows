using FetchNASAAPIApp.DTOs;
using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.Services.Interfaces
{
    public interface INasaApiService
    {
        Task<List<PictureDTO>> FetchData(NasaApiRequestParams nasaApiRequestParams);
    }
}
