using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IListsRepository : IEFRepository<UserList>
{
    Task<ListItem> AddItemToListAsync(int id, ListItem item);
    Task<UserList?> GetByIdAsync(
         int id,
         bool includeItems = true,
         bool includeItemTemplate = true,
         bool includeTopic = true,
         bool trackEntity = false);
    Task<string?> GetOwnerIdAsync(int listId);
}
