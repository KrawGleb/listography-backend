using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class ListItemTemplateEntityConfiguration : IEntityTypeConfiguration<ListItemTemplate>
{
    public void Configure(EntityTypeBuilder<ListItemTemplate> builder)
    {
        ConfigureRelationships(builder);
        ConfigureConstraints(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<ListItemTemplate> builder)
    {
        builder
            .HasOne(t => t.UserList)
            .WithOne(l => l.ItemTemplate)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(t => t.CustomFields)
            .WithOne(f => f.ListItemTemplate)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private void ConfigureConstraints(EntityTypeBuilder<ListItemTemplate> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired(false);
    }
}
