using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class KategoriDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
