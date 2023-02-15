using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string name { get; set; }
        [Range(18,50)]
        public int age { get; set; }
    }

}
