using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;
using TeamSystem.ServiceLayer;

namespace TeamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(UserDTO model)
        {
            var post = _userService.AddUsers(model);
            if (post == null)
            {
                return BadRequest("ERROR WHILE SAVING USER");
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> PostLoginDetails(UserLogIn _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _userService.CheckUser(_userData);
                if (!resultLoginCheck)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    var loggedUser = _userService.GetUserByUsername(_userData.Username);

                    var subject = new ClaimsIdentity(new[]
                     {
                      new Claim(ClaimTypes.Name, loggedUser.Username),
                      new Claim(ClaimTypes.Role, loggedUser.Role.ToUpper())
                    });

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signingCredentials = new SigningCredentials(
                                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                                   SecurityAlgorithms.HmacSha512Signature
                               );
                    var expires = DateTime.UtcNow.AddMinutes(10);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"],
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

    }
}
