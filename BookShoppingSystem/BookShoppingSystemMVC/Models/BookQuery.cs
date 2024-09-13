namespace BookShoppingSystemMVC.Models
{
    public class BookQuery
    {
        public int? GenreId { get; set; }

        public const int BooksPerPage = 8;
        public int CurrentPage { get; set; } = 1;
        public string SearchTerm { get; set; }
        //public OrderBy OrderByClause { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
        public int TotalBooks { get; set; }
    }
}
