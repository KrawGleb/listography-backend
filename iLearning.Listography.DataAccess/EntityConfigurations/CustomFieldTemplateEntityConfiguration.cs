using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class CustomFieldTemplateEntityConfiguration : IEntityTypeConfiguration<CustomFieldTemplate>
{
    public void Configure(EntityTypeBuilder<CustomFieldTemplate> builder)
    {
        ConfigureRelationships(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<CustomFieldTemplate> builder)
    {
        builder
            .HasMany(c => c.SelectOptions)
            .WithOne(s => s.CustomFieldTemplate)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
