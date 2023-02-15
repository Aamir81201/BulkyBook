using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Book
    {   
        [Key]
        public int bookId { get; set; }
        [Required]
        public string title { get; set; }
        [Range(0, 1000)]
        public float price { get; set; }
    }
}
