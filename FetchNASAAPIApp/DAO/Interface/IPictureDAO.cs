using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.DAO.Interface
{
    public interface IPictureDAO
    {
        Task<(bool isSuccess, string message)> CreateEntryAsync(Picture picture);
        Task<Picture> GetPictureByDateAsync(DateOnly date);
    }
}
