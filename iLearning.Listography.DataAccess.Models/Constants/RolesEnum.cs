using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.DataAccess.Models.Constants;

public static class RolesEnum
{
    public static readonly IEnumerable<IdentityRole> Roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole()
        {
            Name = "User",
            NormalizedName = "USER",
        }
    };
}
