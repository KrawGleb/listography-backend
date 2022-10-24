using iLearning.Listography.DataAccess.Helpers.DataSeeding;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace iLearning.Listography.DataAccess.Implementations;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    private DbSet<UserList> Lists { get; set; }
    private DbSet<ListTag> Tags { get; set; }
    private DbSet<ListTopic> Topics { get; set; }
    private DbSet<CustomField> CustomFields { get; set; }
    private DbSet<ListItem> Items { get; set; }
    private DbSet<ListItemTemplate> ItemTemplates { get; set; }
    private DbSet<Like> Likes { get; set; }
    private DbSet<Comment> Comments { get; set; }
    private DbSet<SelectOption> SelectOptions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SeedWithRoles();
        builder.SeedWithTopics();

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
