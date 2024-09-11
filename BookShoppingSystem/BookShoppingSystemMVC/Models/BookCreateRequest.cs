using System.ComponentModel.DataAnnotations;

namespace BookShoppingSystemMVC.Models
{
    public class BookCreateRequest
    {
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; init; }

        [Required]
        [Display(Name = "Book Author")]
        public string BookAuthor { get; init; }

        [Display(Name = "Book Price")]
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
