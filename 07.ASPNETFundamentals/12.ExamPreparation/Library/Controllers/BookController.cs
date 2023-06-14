using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly LibraryDbContext data;

        public BookController(LibraryDbContext libraryDbContext)
        {
            data = libraryDbContext;
        }

        public IActionResult All()
        {
            var books = data.Books
                .Select(b => new AllBookView()
                {
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl
                }).ToArray();

            return View(books);
        }

        public IActionResult Mine()
        {
            var userId = GetuserId();

            var books = data.UserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBookView()
                {
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name,
                    Id = b.Book.Id,
                    ImageUrl = b.Book.ImageUrl
                }).ToList();

            return View(books);
        }
    }
}
