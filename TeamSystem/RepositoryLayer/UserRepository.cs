using Microsoft.AspNetCore.Mvc;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _db;
        public UserRepository(ApiDbContext db)
        {
            _db = db;
        }

        public Task<User> AddUsers(User model)
        {
            try
            {
                _db.User.Add(model);
                _db.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUserByUsername(string username)
        {
            return _db.User.FirstOrDefault(x => x.Username == username);
        }

        public bool LogIn(UserLogIn model)
        {
            return _db.User.Any(x=>x.Username == model.Username && x.Password == model.Password);
        }
    }
}
