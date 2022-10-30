using iLearning.Listography.DataAccess.Models.Constraints;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class ListTopicEntityConfiguration : IEntityTypeConfiguration<ListTopic>
{
    public void Configure(EntityTypeBuilder<ListTopic> builder)
    {
        ConfigureConstraints(builder);
    }

    private void ConfigureConstraints(EntityTypeBuilder<ListTopic> builder)
    {
        builder
            .Property(e => e.Name)
            .HasMaxLength(ListTopicConstraints.NameMaxLength)
            .IsRequired(true);
    }
}
