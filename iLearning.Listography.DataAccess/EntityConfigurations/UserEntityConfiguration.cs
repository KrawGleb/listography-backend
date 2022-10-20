using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasMany(a => a.Lists)
            .WithOne(l => l.ApplicationUser)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(a => a.Comments)
            .WithOne(c => c.ApplicationUser)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(a => a.Likes)
            .WithOne(l => l.ApplicationUser)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
