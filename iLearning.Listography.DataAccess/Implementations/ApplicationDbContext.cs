using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations;

public class ApplicationDbContext : IdentityDbContext<Account, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    private DbSet<UserList> Lists { get; set; }
    private DbSet<ListTag> Tags { get; set; }
    private DbSet<ListTopic> Topics { get; set; }
    private DbSet<CustomField> CustomFields { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );

        base.OnModelCreating(builder);
    }
}
