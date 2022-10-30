using iLearning.Listography.DataAccess.Models.Constraints;
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
            .HasMaxLength(CustomFieldConstraints.NameMaxLength)
            .IsRequired();

        builder
            .Property(e => e.StringValue)
            .HasMaxLength(CustomFieldConstraints.StringMaxLength)
            .IsRequired(false);

        builder
            .Property(e => e.TextValue)
            .HasMaxLength(CustomFieldConstraints.TextMaxLength)
            .IsRequired(false);

        builder
            .Property(e => e.NumberValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);
    }
}
