using AutoMapper;
using BookShoppingSystemMVC.Data;
using BookShoppingSystemMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingSystemMVC.Repositories
{
    public class BookRepository(BookSystemDbContext dbContext, IMapper mapper) : IBookRepository
    {
        public async Task<BookDto> CreateBook(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return new BookDto();
        }

        public async Task<IEnumerable<GenreDto>> GetBookGenres()
        {
            var genres = await dbContext.Genres.AsNoTracking().ToListAsync();
            var genresDto = mapper.Map<List<GenreDto>>(genres);

            return genresDto;
        }
    }
}
