using Microsoft.AspNetCore.Mvc;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.ServiceLayer
{
    public interface IUserService
    {
        public Task<User> AddUsers(UserDTO model);
        public bool CheckUser(UserLogIn model);
        public User GetUserByUsername(string username);
    }
}
