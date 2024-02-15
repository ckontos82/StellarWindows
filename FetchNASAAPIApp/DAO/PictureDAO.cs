using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp.DAO
{
    public class PictureDAO : IPictureDAO
    {
        private readonly ApplicationDbContext _context;

        public PictureDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateEntryAsync(Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
        }

        public async Task<Picture> GetPictureByDateAsync(DateOnly date)
        {
            return await _context.Pictures.FirstOrDefaultAsync(p => p.Date == date);
        }
    }
}
