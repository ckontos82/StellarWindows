using FetchNASAAPIApp.Models;
using System.Collections;

namespace FetchNASAAPIApp.DAO.Interface
{
    public interface IPictureDAO
    {
        Task<(bool isSuccess, string message)> CreateEntryAsync(Picture picture);
        Task<IEnumerable<Picture>> GetAllPicturesAsync();
        Task<Picture> GetPictureByDateAsync(DateOnly date);
    }
}
