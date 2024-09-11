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

            if (!genres.Any(f => f.Id == book.GenreId))
            {
                this.ModelState.AddModelError(nameof(book.GenreId), "Genre does not exist!");
            }

            if (!ModelState.IsValid)
            {
                book.Genres = genres;

                return View(book);
            }

            await bookService.CreateFragrance(book);
            return RedirectToAction("All");
        }
    }
}
