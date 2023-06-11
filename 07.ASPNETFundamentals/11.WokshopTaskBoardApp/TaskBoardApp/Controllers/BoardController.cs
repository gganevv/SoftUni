using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext Data;

        public BoardController(TaskBoardAppDbContext context)
        {
            Data = context;
        }

        public async Task<IActionResult> All()
        {
            var boards = await Data
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b
                        .Tasks
                        .Select(t => new Models.Task.TaskViewModel()
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
