using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface IUserRepository
	{
        Task<ICollection<User>> GetUsersAsync();
        Task<User> GetUserAsync(int userId);
        Task<bool> PostUserAsync(User user);
        Task PatchUserAsync(User user);
        Task DeleteUserAsync(User user);
        bool UsersEntityExists();
        bool UserExists(int userId);
    }
}

