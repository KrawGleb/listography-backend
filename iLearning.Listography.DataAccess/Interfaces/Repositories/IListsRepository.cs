using iLearning.Listography.DataAccess.Helpers.Options;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IListsRepository : IEFRepository<UserList>
{
    Task<UserList?> GetByIdAsync(Action<ListQueryOptions>? setupQuery, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserList>> GetLargestAsync(int count, CancellationToken cancellationToken = default);
    Task<string?> GetOwnerIdAsync(int listId, CancellationToken cancellationToken = default);
    Task<ListItem> AddItemToListAsync(int id, ListItem item, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserList entity, CancellationToken cancellationToken = default);
}
