using AutoMapper;
using BookShoppingSystemMVC.Models;
using BookShoppingSystemMVC.Repositories;

namespace BookShoppingSystemMVC.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public async Task<BookDto> CreateBook(Book book)
        {
            return await bookRepository.CreateBook(book);
        }

        public Task<IEnumerable<GenreDto>> GetBookGenres()
        {
            return bookRepository.GetBookGenres();
        }

        public Task<IEnumerable<BookDto>> GetBooks(BookQuery bookQuery)
        {
            return bookRepository.GetBooks(bookQuery);
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await bookRepository.GetGenreById(id);
        }
    }
}
