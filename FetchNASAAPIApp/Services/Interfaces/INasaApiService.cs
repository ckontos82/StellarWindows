using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.Services.Interfaces
{
    public interface INasaApiService
    {
        Task<List<Picture>> FetchData(NasaApiRequestParams nasaApiRequestParams);
    }
}
