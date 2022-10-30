using iLearning.Listography.DataAccess.Models.Constraints;
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
            .HasMany(t => t.CustomFields)
            .WithOne(f => f.ListItemTemplate)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureConstraints(EntityTypeBuilder<ListItemTemplate> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(ListItemTemplateConstraints.NameMaxLength)
            .IsRequired(false);
    }
}
