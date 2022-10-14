using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.DataAccess.Models.Identity;

public class Account : IdentityUser
{
    public ICollection<UserList>? Lists { get; set; }
    public AccountState State { get; set; }
    public string? SelectedLanguage { get; set; }
    public string? SelectedTheme { get; set; }
}
