using Microsoft.EntityFrameworkCore;
using StackOverflowSimplified.Entities;

namespace StackOverflowSimplified.Entites
{
    public class StackOverflowContext : DbContext
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
