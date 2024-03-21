using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSystem.Models
{
    public class User
    {
        [Key] // This marks the id property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //
        public long id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
