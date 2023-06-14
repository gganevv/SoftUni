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
    }
}
