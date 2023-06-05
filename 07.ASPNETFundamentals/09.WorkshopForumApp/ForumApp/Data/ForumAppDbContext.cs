using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) 
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Post> Posts { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Post>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
