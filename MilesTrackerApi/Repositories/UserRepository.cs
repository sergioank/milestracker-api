using System;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly DataContext _context;


        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteUserAsync(User user)
        {
            if (!UsersEntityExists())
                return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            var usersList = await _context.Users.ToListAsync();
            return usersList;
        }

        public async Task PatchUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostUserAsync(User user)
        {
            var usersExists = UsersEntityExists();
            if (!usersExists)
                return false;

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(c => c.User_Id == userId);
        }

        public bool UsersEntityExists()
        {
            var usersExists = _context.Users != null ? true : false;
            return usersExists;
        }
    }
}

