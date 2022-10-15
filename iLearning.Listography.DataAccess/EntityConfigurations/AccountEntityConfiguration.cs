using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasMany(a => a.Lists)
            .WithOne(l => l.Account)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(a => a.Comments)
            .WithOne(c => c.Account)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(a => a.Likes)
            .WithOne(l => l.Account)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
