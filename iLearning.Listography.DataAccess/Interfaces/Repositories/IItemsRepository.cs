using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IItemsRepository : IEFRepository<ListItem>
{
    Task<IEnumerable<ListItem>> GetLastCreated(int count);
    Task UpdateAsync(ListItem oldEntity, ListItem newEntity);
    Task<int?> GetListIdAsync(int id);
    Task AddLike(int id, Like like);
    Task AddComment(int id, Comment comment);
}
