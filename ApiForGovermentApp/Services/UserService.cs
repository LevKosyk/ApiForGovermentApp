using ApiForGovermentApp.Data;
using ApiForGovermentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiForGovermentApp.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<bool> AddUser(string login, string password);
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

        public async Task<bool> AddUser(string login, string password)
        {
            try
            {
                Console.WriteLine($"Adding user: {login}");
                Guid id = Guid.NewGuid();
                User user = new User { Id = id.ToString(), Login = login, Password = password };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                Console.WriteLine("User added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public async Task<User> FindUser(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> FindUser(string login, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return user != null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserExists(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }
    }
}
