using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class ListTagEntityConfiguration : IEntityTypeConfiguration<ListTag>
{
    public void Configure(EntityTypeBuilder<ListTag> builder)
    {
        ConfigureConstraints(builder);
    }

    private void ConfigureConstraints(EntityTypeBuilder<ListTag> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();
    }
}
