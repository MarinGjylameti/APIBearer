using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;

namespace TeamSystem.ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public Task<User> AddUsers(UserDTO model)
        {
            var post = _mapper.Map<User>(model);
            return _userRepository.AddUsers(post);
        }

        public bool CheckUser(UserLogIn model)
        {
            return _userRepository.LogIn(model);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
