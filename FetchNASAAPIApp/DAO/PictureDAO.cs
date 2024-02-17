﻿using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Models;
using FetchNASAAPIApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FetchNASAAPIApp.DAO
{
    public class PictureDAO : IPictureDAO
    {
        private readonly ApplicationDbContext _context;

        public PictureDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool isSuccess, string message)> CreateEntryAsync(Picture picture)
        {
            if (await _context.Pictures.AnyAsync(p => p.Date == picture.Date))
            {
                return (false, "Picture already exists in the database.");
            }


            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return (true, "Picture saved successfully.");
        }

        public async Task<IEnumerable<Picture>> GetAllPicturesAsync()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetPictureByDateAsync(DateOnly date)
        {
            return await _context.Pictures.FirstOrDefaultAsync(p => p.Date == date);
        }
    }
}
