using iLearning.Listography.DataAccess.Models.Constraints;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class SelectOptionEntityConfiguration : IEntityTypeConfiguration<SelectOption>
{
    public void Configure(EntityTypeBuilder<SelectOption> builder)
    {
        ConfigureConstraints(builder);
    }

    private void ConfigureConstraints(EntityTypeBuilder<SelectOption> builder)
    {
        builder
            .Property(s => s.Text)
            .HasMaxLength(SelectOptionConstraints.TextMaxLength);
    }
}
