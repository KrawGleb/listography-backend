using iLearning.Listography.DataAccess.Models.Constraints;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class UserListEntityConfiguration : IEntityTypeConfiguration<UserList>
{
    public void Configure(EntityTypeBuilder<UserList> builder)
    {
        ConfigureRelationships(builder);
        ConfigureConstraints(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<UserList> builder)
    {
        builder
            .HasMany(l => l.Items)
            .WithOne(i => i.UserList)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(l => l.ItemTemplate)
            .WithOne(t => t.UserList)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(l => l.Topic)
            .WithMany(t => t.UserLists)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private void ConfigureConstraints(EntityTypeBuilder<UserList> builder)
    {
        builder
            .Property(e => e.Title)
            .HasMaxLength(UserListConstraints.TitleMaxLength)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .HasMaxLength(UserListConstraints.DescriptionMaxLength)
            .IsRequired(false);

        builder
            .Property(e => e.ImageUrl)
            .HasMaxLength(UserListConstraints.ImageUrlMaxLength)
            .IsRequired(false);
    }
}
