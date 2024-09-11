using BookShoppingSystemMVC.Models;

namespace BookShoppingSystemMVC.Repositories
{
    public interface IBookRepository
    {
        Task<BookDto> CreateBook(Book fragrance);
        Task<IEnumerable<GenreDto>> GetBookGenres();
    }
}
