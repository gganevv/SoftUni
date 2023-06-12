using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext Data;

        public TaskController(TaskBoardAppDbContext context)
        {
            Data = context;
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            Data.Models.Task task = new Data.Models.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await Data.Tasks.AddAsync(task);
            await Data.SaveChangesAsync();

            var boards = Data.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await Data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await Data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await Data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await Data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await Data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await Data.Tasks.FindAsync(taskModel.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            Data.Tasks.Remove(task);
            await Data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards()
            => Data
            .Boards
            .Select(x => new TaskBoardModel()
            {
                Id = x.Id,
                Name = x.Name
            });
    }
}
