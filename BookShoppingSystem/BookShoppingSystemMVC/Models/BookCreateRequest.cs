using System.ComponentModel.DataAnnotations;

namespace BookShoppingSystemMVC.Models
{
    public class BookCreateRequest
    {
        [Required]
        public string BookName { get; init; }

        [Required]
        public string BookAuthor { get; init; }
        public double BookPrice { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Display(Name = "Genre")]
        public int GenreId { get; init; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
