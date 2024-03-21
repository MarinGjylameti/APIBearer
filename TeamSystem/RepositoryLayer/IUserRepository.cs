using Microsoft.AspNetCore.Mvc;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public interface IUserRepository
    {
        public Task<User> AddUsers(User model);
        User GetUserByUsername(string username);
        bool LogIn(UserLogIn model);
    }
}
