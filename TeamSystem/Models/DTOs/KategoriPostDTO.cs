using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class KategoriPostDTO
    {
        [Required(ErrorMessage = "KategoriId is required")]
        public long KategoriId { get; set; }
        [Required(ErrorMessage = "PostimId is required")]
        public long PostimId { get; set; }
    }
}
