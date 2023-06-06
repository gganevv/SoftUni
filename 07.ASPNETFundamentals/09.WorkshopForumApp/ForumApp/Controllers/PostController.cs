using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext Data;

        public PostController(ForumAppDbContext data)
        {
            this.Data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var posts = await Data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await Data.Posts.AddAsync(post);
            await Data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await Data.Posts.FindAsync(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await Data.Posts.FindAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await Data.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
