using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowSimplified.Entities.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> eb)
        {
            eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(x => x.ModifiedDate).ValueGeneratedOnUpdate();
        }
    }
}
