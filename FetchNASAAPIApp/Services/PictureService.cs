using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        public async Task<(bool, string)> CreateEntryAsync(Picture picture)
        {
            return await _pictureDAO.CreateEntryAsync(picture);
        }

        public async Task<IEnumerable<Picture>> GetAllPicturesAsync()
        {
            return await _pictureDAO.GetAllPicturesAsync();
        }

        public async Task<(bool, string)> DeleteEntryAsync(Picture picture)
        {
            return await _pictureDAO.DeleteEntryAsync(picture);
        }
    }
}
