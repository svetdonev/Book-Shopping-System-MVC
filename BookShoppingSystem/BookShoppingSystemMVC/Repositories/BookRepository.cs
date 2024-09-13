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
            return mapper.Map<Book, BookDto>(book);
        }

        public async Task<IEnumerable<GenreDto>> GetBookGenres()
        {
            var genres = await dbContext.Genres.AsNoTracking().ToListAsync();
            var genresDto = mapper.Map<List<GenreDto>>(genres);

            return genresDto;
        }

        public async Task<IEnumerable<BookDto>> GetBooks(BookQuery bookQuery)
        {
            var query = dbContext.Books
                .Include(f => f.Genre)
                .AsQueryable();

            if (bookQuery.GenreId.HasValue)
            {
                query = query.Where(f => f.GenreId == bookQuery.GenreId.Value);
            }

            if (!string.IsNullOrEmpty(bookQuery.SearchTerm))
            {
                query = query.Where(f => f.Name.Contains(bookQuery.SearchTerm));
            }

            bookQuery.TotalBooks = await query.CountAsync();

            query = query
                .Skip((bookQuery.CurrentPage - 1) * BookQuery.BooksPerPage)
                .Take(BookQuery.BooksPerPage);

            var fragrances = await query.AsNoTracking().ToListAsync();

            return mapper.Map<List<Book>, List<BookDto>>(fragrances);
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await dbContext.Genres.FindAsync(id);
        }
    }
}
