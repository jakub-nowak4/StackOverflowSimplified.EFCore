using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowSimplified.Entities.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> eb)
        {
            eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(x => x.ModifiedDate).ValueGeneratedOnUpdate();
        }
    }
}
