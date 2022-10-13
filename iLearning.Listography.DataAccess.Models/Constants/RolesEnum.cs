using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.DataAccess.Models.Constants;

public static class RolesEnum
{
    public const string Admin = "Admin";
    public const string User = "User";

    public static readonly IEnumerable<IdentityRole> Roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Name = Admin,
            NormalizedName = Admin.ToUpper()
        },
        new IdentityRole()
        {
            Name = User,
            NormalizedName = User.ToUpper(),
        }
    };
}
