using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace iLearning.Listography.DataAccess.Models.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserList>? Lists { get; set; }
    public UserState State { get; set; }
    public string? SelectedLanguage { get; set; }
    public string? SelectedTheme { get; set; }

    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }

    [JsonIgnore]
    public ICollection<Like>? Likes { get; set; }

    public bool IsBlocked() 
        => State == UserState.Blocked;
}
