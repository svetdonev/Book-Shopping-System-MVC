using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingSystemMVC.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? GenreName { get; set; }
        public List<Book> Books { get; set; }
    }
}
