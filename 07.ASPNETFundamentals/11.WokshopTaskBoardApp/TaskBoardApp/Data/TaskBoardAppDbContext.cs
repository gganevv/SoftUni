using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<IdentityUser>
    {
        private IdentityUser TestUser { get; set; }

        private Board OpenBoard { get; set; }

        private Board InProgressBoard { get; set; }

        private Board DoneBoard { get; set; }

        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Board> Boards { get; set; } = null!;

        public DbSet<Models.Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Models.Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t =>t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder
                .Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            builder
                .Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder
                .Entity<Models.Task>()
                .HasData(new Models.Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implenet better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Models.Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Models.Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Windows Forms desktop client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Models.Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implenet [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id
                }); ;

            base.OnModelCreating(builder);
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            TestUser = new IdentityUser()
            {
                UserName = "test@abv.bg",
                NormalizedUserName = "TEST@ABV.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "test");
        }
        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}