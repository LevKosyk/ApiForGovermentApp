using ApiForGovermentApp.Data;
using ApiForGovermentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Services
{
    public interface IPhotoService
    {
        Task<Photo> GetPhotoById(string id);
        Task<bool> AddPhoto(string longetude, string latitude, string Url, DateTime date, User user, string description, string Situation);
        Task<List<Photo>> GetPhotosByDate(DateTime date, string userId);
        Task<List<DateTime>> GetDatesWhereIsPhotoByMonth(string userId, int month, int year);
    }

    public class PhotoService : IPhotoService
    {
        private readonly ApiDbContext _context;

        public PhotoService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Photo> GetPhotoById(string id)
        {
            return await _context.Photos.FindAsync(id);
        }

        public async Task<bool> AddPhoto(string longitude, string latitude, string url, DateTime date, User user, string description, string Situation)
        {
            try
            {
                var photo = new Photo
                {
                    Date = date,
                    latitude = latitude,
                    longetude = longitude,
                    Url = url,
                    User = user,
                    UserId = user.Id,
                    Description = description,
                    Situation = Situation
                };

                await _context.Photos.AddAsync(photo);
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding photo: {ex.Message}");
                return false; 
            }
        }


        public async Task<List<Photo>> GetPhotosByDate(DateTime date, string userId)
        {
            Console.WriteLine(date);
            return await _context.Photos
                .Where(p => p.Date.Date == date.Date && p.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<DateTime>> GetDatesWhereIsPhotoByMonth(string userId, int month, int year)
        {
            return await _context.Photos
                .Where(p => p.UserId == userId && p.Date.Month == month && p.Date.Year == year)
                .Select(p => p.Date)
                .ToListAsync();
        }
    }
}
