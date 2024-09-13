using BookShoppingSystemMVC.Models;

namespace BookShoppingSystemMVC.Services
{
    public interface IBookService
    {
        Task<BookDto> CreateBook(Book book);
        Task<IEnumerable<GenreDto>> GetBookGenres();
        Task<IEnumerable<BookDto>> GetBooks(BookQuery bookQuery);
        Task<Genre> GetGenreById(int id);
    }
}
