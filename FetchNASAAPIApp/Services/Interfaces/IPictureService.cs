using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.Services.Interfaces
{
    public interface IPictureService
    {
        Task<Picture> GetPictureByDateAsync(DateOnly date);
        Task<(bool, string)> CreateEntryAsync(Picture picture);
        Task<IEnumerable<Picture>> GetAllPicturesAsync();
    }
}
