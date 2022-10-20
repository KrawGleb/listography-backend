using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class LikeEntityConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder
          .HasOne(l => l.ApplicationUser)
          .WithMany(a => a.Likes)
          .OnDelete(DeleteBehavior.NoAction);
    }
}
