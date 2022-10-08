using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.Models;

public class HomeInfo
{
    public IEnumerable<ListTag>? Tags { get; set; }
    public IEnumerable<UserList>? LargestLists { get; set; }
    public IEnumerable<ItemDescription>? LastCreatedItems { get; set; }
}
