using System.ComponentModel.DataAnnotations;

namespace BookShoppingSystemMVC.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookImage { get; set; }
        public double BookPrice { get; set; }
        public GenreDto Genre { get; set; }
    }
}
