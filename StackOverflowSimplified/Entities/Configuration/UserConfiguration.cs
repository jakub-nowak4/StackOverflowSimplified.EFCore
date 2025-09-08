using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowSimplified.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> eb)
        {
            eb.Property(x => x.FullName).HasMaxLength(100);
            eb.Property(x => x.Username).HasMaxLength(35);
        }
    }
}
