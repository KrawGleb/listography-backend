using iLearning.Listography.DataAccess.Models.Constraints;
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
            .HasMaxLength(ListTagConstraints.NameMaxLength)
            .IsRequired();
    }
}
