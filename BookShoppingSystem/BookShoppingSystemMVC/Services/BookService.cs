using AutoMapper;
using BookShoppingSystemMVC.Models;
using BookShoppingSystemMVC.Repositories;

namespace BookShoppingSystemMVC.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public Task<BookDto> CreateFragrance(BookCreateRequest request)
        {
            var book = mapper.Map<BookCreateRequest, Book>(request);
            return bookRepository.CreateBook(book);
        }

        public Task<IEnumerable<GenreDto>> GetBookGenres()
        {
            return bookRepository.GetBookGenres();
        }
    }
}
