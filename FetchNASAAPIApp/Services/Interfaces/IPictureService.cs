using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.Services.Interfaces
{
    public interface IPictureService
    {
        Task<Picture> GetPictureByDateAsync(DateOnly date);
        Task CreateEntryAsync(Picture picture);
    }
}
