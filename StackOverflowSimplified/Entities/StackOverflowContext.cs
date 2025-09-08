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

            //Relations

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasMany(u => u.Questions).WithOne(q => q.Author).HasForeignKey(q => q.AuthorId);
                eb.HasMany(u => u.Answers).WithOne(a => a.Author).HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.ClientCascade);
                eb.HasMany(u => u.Comments).WithOne(c => c.Author).HasForeignKey(c => c.AuthorId);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.HasOne(c => c.Question).WithMany(q => q.Comments).HasForeignKey(c => c.QuestionId);
                eb.HasOne(c => c.Answer).WithMany(a => a.Comments).HasForeignKey(c => c.AnswerId);
                eb.ToTable(t => t.HasCheckConstraint("CK_Comment_Target", "([QuestionId] IS NOT NULL AND [AnswerId] IS NULL) OR " +
        "([QuestionId] IS NULL AND [AnswerId] IS NOT NULL)"));
            });


            modelBuilder.Entity<Question>().HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a => a.QuestionId);
        }
    }
}
