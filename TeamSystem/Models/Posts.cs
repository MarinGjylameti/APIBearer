using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models
{
    public class Posts
    {
        [Key] // This marks the id property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //
        public long id {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime Date_Krijimi{ get; set; }
        public DateTime Date_Publikimi { get; set; }
        public long UserId { get; set; }
    }
}
