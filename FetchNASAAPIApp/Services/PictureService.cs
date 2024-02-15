using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services.Interfaces;

namespace FetchNASAAPIApp.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureDAO _pictureDAO;

        public PictureService(IPictureDAO pictureDAO)
        {
            _pictureDAO = pictureDAO;
        }

        public async Task<Picture> GetPictureByDateAsync(DateOnly date)
        {
            return await _pictureDAO.GetPictureByDateAsync(date);
        }

        public async Task CreateEntryAsync(Picture picture)
        {
            await _pictureDAO.CreateEntryAsync(picture);
        }
    }
}
