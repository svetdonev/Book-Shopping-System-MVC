using AutoMapper;
using BookShoppingSystemMVC.Models;
using BookShoppingSystemMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingSystemMVC.Controllers
{
    public class BookController(IBookService bookService, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new BookCreateRequest
            {
                Genres = await bookService.GetBookGenres()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookCreateRequest book)
        {
            var genres = (await bookService.GetBookGenres()).ToList();
            book.Genres = genres;

            if (!genres.Any(g => g.Id == book.GenreId))
            {
                ModelState.AddModelError(nameof(book.GenreId), "Selected genre does not exist.");
            }

            if (!ModelState.IsValid)
            {
                book.Genres = await bookService.GetBookGenres(); // Repopulate genres on validation error
                return View(book);
            }

            // Load the Genre from the database
            var genre = await bookService.GetGenreById(book.GenreId);
            if (genre == null)
            {
                ModelState.AddModelError(nameof(book.GenreId), "Genre not found.");
                return View(book);
            }

            // Map the BookCreateRequest to Book and set the Genre
            var mappedBook = mapper.Map<BookCreateRequest, Book>(book);
            mappedBook.Genre = genre;

            // Now create the book
            await bookService.CreateBook(mappedBook);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] BookQuery query)
        {
            var fragrances = await bookService.GetBooks(query);
            var categories = await bookService.GetBookGenres();

            query.Genres = categories;
            query.Books = fragrances;

            return View(query);
        }
    }
}
