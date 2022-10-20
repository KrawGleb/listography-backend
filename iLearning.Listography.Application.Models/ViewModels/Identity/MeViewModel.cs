using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.ViewModels.Identity;

public class MeViewModel
{
    public string? UserName { get; set; }
    public IEnumerable<UserList>? Lists { get; set; }
}
