using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class CustomFieldEntityConfiguration : IEntityTypeConfiguration<CustomField>
{
    public void Configure(EntityTypeBuilder<CustomField> builder)
    {
        ConfigureRelationships(builder);
        ConfigureConstraints(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<CustomField> builder)
    {
        builder
            .HasOne(f => f.ListItem)
            .WithMany(l => l.CustomFields)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(f => f.ListItemTemplate)
            .WithMany(l => l.CustomFields)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private void ConfigureConstraints(EntityTypeBuilder<CustomField> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(e => e.StringValue)
            .HasMaxLength(100)
            .IsRequired(false);

        builder
            .Property(e => e.TextValue)
            .HasMaxLength(600)
            .IsRequired(false);

        builder
            .Property(e => e.NumberValue)
            .IsRequired(false);
    }
}
