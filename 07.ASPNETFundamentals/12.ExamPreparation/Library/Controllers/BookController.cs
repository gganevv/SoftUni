using Library.Data;
using Library.Data.Models;
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

        public IActionResult Add()
        {
            var categories = data.Categories
                .Select(c => new Category()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

            var model = new AddBookView
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddBookView model)
        {
            var categories = data.Categories
               .Select(c => new Category()
               {
                   Id = c.Id,
                   Name = c.Name
               }).ToList();

            model.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating
            };

            data.Books.Add(book);
            data.SaveChanges();

            return RedirectToAction("All", "Book");
        }
    }
}
