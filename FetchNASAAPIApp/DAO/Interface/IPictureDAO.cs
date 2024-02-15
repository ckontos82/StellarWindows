using FetchNASAAPIApp.Models;

namespace FetchNASAAPIApp.DAO.Interface
{
    public interface IPictureDAO
    {
        Task CreateEntryAsync(Picture picture);
        Task<Picture> GetPictureByDateAsync(DateOnly date);
    }
}
