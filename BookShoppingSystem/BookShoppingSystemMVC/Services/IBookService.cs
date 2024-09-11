using BookShoppingSystemMVC.Models;

namespace BookShoppingSystemMVC.Services
{
    public interface IBookService
    {
        Task<BookDto> CreateFragrance(BookCreateRequest request);
        Task<IEnumerable<GenreDto>> GetBookGenres();
    }
}
