using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowSimplified.Entities.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> eb)
        {
            eb.Property(x => x.Votes).HasDefaultValue(0);
            eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(x => x.ModifiedDate).ValueGeneratedOnUpdate();
        }
    }
}
