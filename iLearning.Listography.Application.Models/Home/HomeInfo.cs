using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models.Home;

public class HomeInfo
{
    public IEnumerable<ListTag>? Tags { get; set; }
    public IEnumerable<UserList>? LargestLists { get; set; }
    public IEnumerable<ItemShortDescription>? LastCreatedItems { get; set; }
}
