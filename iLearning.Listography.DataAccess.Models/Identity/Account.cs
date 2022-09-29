using iLearning.Listography.DataAccess.Models.List;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.DataAccess.Models.Identity;

public class Account : IdentityUser
{
    public ICollection<UserList>? Lists { get; set; }
}
