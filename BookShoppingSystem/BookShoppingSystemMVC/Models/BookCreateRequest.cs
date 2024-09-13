using System.ComponentModel.DataAnnotations;

namespace BookShoppingSystemMVC.Models
{
    public class BookCreateRequest
    {
        [Required(ErrorMessage = "Book name is required.")]
        [Display(Name = "Book Name")]
        public string BookName { get; init; }

        [Display(Name = "Book Author")]
        [Required(ErrorMessage = "Author name is required.")]
        public string BookAuthor { get; init; }

        [Display(Name = "Book Price")]
        public double BookPrice { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }


        [Required(ErrorMessage = "Genre selection is required.")]
        [Display(Name = "Genre")]
        public int GenreId { get; init; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
