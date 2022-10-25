using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Helpers.DataSeeding;

public static class UsersSeedingExtension
{
    public static void SeedWithAdmins(this ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUser>()
            .HasData(AdminsEnum.Creator);
    }
}
