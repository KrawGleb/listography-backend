using iLearning.Listography.DataAccess.Models.Constraints;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

internal class ListItemEntityConfiguration : IEntityTypeConfiguration<ListItem>
{
    public void Configure(EntityTypeBuilder<ListItem> builder)
    {
        ConfigureRelationships(builder);
        ConfigureConstraints(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<ListItem> builder)
    {
        builder
           .HasMany(i => i.CustomFields)
           .WithOne(c => c.ListItem)
           .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(i => i.Comments)
            .WithOne(c => c.ListItem)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(i => i.Likes)
            .WithOne(l => l.ListItem)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(i => i.Tags)
            .WithOne(t => t.ListItem)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureConstraints(EntityTypeBuilder<ListItem> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(ListItemConstraints.NameMaxLength)
            .IsRequired();
    }
}
