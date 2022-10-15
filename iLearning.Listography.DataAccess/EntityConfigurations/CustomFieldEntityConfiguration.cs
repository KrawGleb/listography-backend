using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class CustomFieldEntityConfiguration : IEntityTypeConfiguration<CustomField>
{
    public void Configure(EntityTypeBuilder<CustomField> builder)
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
}
