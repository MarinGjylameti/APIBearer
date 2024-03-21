using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class PostsDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime Date_Krijimi { get; set; }
        [Required]
        public DateTime Date_Publikimi { get; set; }
    }
}
