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
        Task<bool> AddPhoto(string longitude, string latitude, string url, DateTime date, User user, string description, string situation, User detectedUser);
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
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await _context.Photos.FindAsync(id);
        }

        public async Task<bool> AddPhoto(string longitude, string latitude, string url, DateTime date, User user, string description, string situation, User detectedUser)
        {
            try
            {
                if (user == null || detectedUser == null)
                    return false;

                var photo = new Photo
                {
                    Date = date,
                    Latitude = latitude,
                    Longitude = longitude,
                    Url = url,
                    User = user,
                    UserId = user.Id,
                    Description = description,
                    Situation = situation,
                    DetectedUser = detectedUser,
                    DetectedUserId = detectedUser.Id
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
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            return await _context.Photos
                .Where(p => p.Date.Date == date.Date && p.UserId == userId)
                .ToListAsync();
        } 
        public async Task<List<Photo>> GetPhotosByDateForCrime(DateTime date, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            return await _context.Photos
                .Where(p => p.Date.Date == date.Date && p.DetectedUserId == userId)
                .ToListAsync();
        }

        public async Task<List<DateTime>> GetDatesWhereIsPhotoByMonth(string userId, int month, int year)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            var firstDayOfMonth = new DateTime(year, month, 1);
            int dayOfWeekIndex = (int)firstDayOfMonth.DayOfWeek;
            int daysBefore = dayOfWeekIndex == 0 ? 6 : dayOfWeekIndex - 1;
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDayOfMonth = new DateTime(year, month, daysInMonth);
            int endDayOfWeekIndex = (int)lastDayOfMonth.DayOfWeek;
            int daysAfter = endDayOfWeekIndex == 0 ? 0 : 7 - endDayOfWeekIndex;
            var startDate = firstDayOfMonth.AddDays(-daysBefore);
            var endDate = lastDayOfMonth.AddDays(daysAfter);
            return await _context.Photos
                .Where(p => (p.UserId == userId || p.DetectedUserId == userId)
                            && p.Date.Date >= startDate.Date
                            && p.Date.Date <= endDate.Date)
                .Select(p => p.Date.Date)
                .Distinct()
                .ToListAsync();
        }

    }
}
