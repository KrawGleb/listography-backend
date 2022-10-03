using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IListsRepository : IEFRepository<UserList>
{
    Task AddItemToListAsync(int id, ListItem item);
    Task<UserList?> GetByIdAsync(
        int id,
        bool includeItems = true,
        bool includeTags = true,
        bool includeItemTemplate = true,
        bool trackEntity = false);
}
