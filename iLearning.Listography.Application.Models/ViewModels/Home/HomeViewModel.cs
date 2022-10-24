using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.ViewModels.Home;

public class HomeViewModel
{
    public IEnumerable<ListTag>? Tags { get; set; }
    public IEnumerable<UserList>? LargestLists { get; set; }
    public IEnumerable<ItemShortViewModel>? LastCreatedItems { get; set; }
}
