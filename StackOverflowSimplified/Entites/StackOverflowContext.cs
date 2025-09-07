using Microsoft.EntityFrameworkCore;

namespace StackOverflowSimplified.Entites
{
    public class StackOverflowContext : DbContext
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options) : base(options)
        {
            
        }
    }
}
