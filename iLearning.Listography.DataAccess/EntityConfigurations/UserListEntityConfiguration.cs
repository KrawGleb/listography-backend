using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class UserListEntityConfiguration : IEntityTypeConfiguration<UserList>
{
    public void Configure(EntityTypeBuilder<UserList> builder)
    {
        builder
           .HasMany(l => l.Items)
           .WithOne(i => i.UserList)
           .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(l => l.Topic)
            .WithMany(t => t.UserLists)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
