using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IListsRepository : IEFRepository<UserList>
{
    Task<ListItem> AddItemToListAsync(int id, ListItem item, CancellationToken cancellationToken = default);
    Task<UserList?> GetByIdAsync(
         int id,
         bool includeItems = true,
         bool includeItemTemplate = true,
         bool includeTopic = true,
         bool trackEntity = false,
         CancellationToken cancellationToken = default);
    Task<string?> GetOwnerIdAsync(int listId, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserList>> GetLargestAsync(int count, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserList entity, CancellationToken cancellationToken = default);
}
