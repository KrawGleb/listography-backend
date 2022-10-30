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
            .HasMany(f => f.SelectOptions)
            .WithMany(s => s.CustomFields)
            .UsingEntity<Dictionary<string, object>>(
                "CustomFieldSelectOption",
                j => j.HasOne<SelectOption>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<CustomField>().WithMany().OnDelete(DeleteBehavior.Cascade));
    }

    private void ConfigureConstraints(EntityTypeBuilder<CustomField> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(e => e.StringValue)
            .HasMaxLength(200)
            .IsRequired(false);

        builder
            .Property(e => e.TextValue)
            .HasMaxLength(3000)
            .IsRequired(false);

        builder
            .Property(e => e.NumberValue)
            .IsRequired(false);
    }
}
