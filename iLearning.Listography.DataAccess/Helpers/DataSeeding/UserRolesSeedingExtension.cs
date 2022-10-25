using iLearning.Listography.DataAccess.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Helpers.DataSeeding;

public static class UserRolesSeedingExtension
{
    public static void SeedWithUserRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = RolesEnum.AdminRole.Id,
                UserId = AdminsEnum.Creator.Id
            });
    }
}
