using iLearning.Listography.DataAccess.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Helpers.DataSeeding;

public static class RolesSeedingExtension
{
    public static void SeedWithRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityRole>()
            .HasData(RolesEnum.Roles);
    }
}
