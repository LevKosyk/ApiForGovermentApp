using ApiForGovermentApp.Data;
using ApiForGovermentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<bool> AddUser(string login, string password, string name, string secondaryName);
        Task<User> FindUser(string login);
        Task<bool> FindUser(string login, string password);
        Task<List<User>> GetAllUsers();
        Task<bool> UserExists(string login);
    }

    public class UserService : IUserService
    {
        private readonly ApiDbContext _context;

        public UserService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> AddUser(string login, string password, string name, string secondaryName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Login = login,
                    Password = password,
                    Name = name,
                    SecondName = secondaryName
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding user: {ex.Message}");
                return false;
            }
        }

        public async Task<User> FindUser(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> FindUser(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return user != null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserExists(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return false;

            return await _context.Users.AnyAsync(u => u.Login == login);
        }
    }
}
