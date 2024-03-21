using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class UserLogIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
