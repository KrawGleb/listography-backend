using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iLearning.Listography.DataAccess.EntityConfigurations;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        ConfigureRelationships(builder);
        ConfigureConstraints(builder);
    }

    private void ConfigureRelationships(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasOne(c => c.ApplicationUser)
            .WithMany(a => a.Comments)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private void ConfigureConstraints(EntityTypeBuilder<Comment> builder)
    {
        builder
            .Property(e => e.Text)
            .HasMaxLength(300)
            .IsRequired();
    }
}
