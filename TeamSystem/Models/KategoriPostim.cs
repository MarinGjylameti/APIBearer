using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models
{
    public class KategoriPostim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public  long ID { get; set; }
        public long KategoriId { get; set; }

        public long PostimId { get; set; }
    }
}

