using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface IItemsRepository : IEFRepository<ListItem>
{
    Task<IEnumerable<ListItem>> GetLastCreatedAsync(int count, CancellationToken cancellationToken = default);
    Task UpdateAsync(ListItem oldEntity, ListItem newEntity, CancellationToken cancellationToken = default);
    Task<int?> GetListIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddLikeAsync(int id, Like like, CancellationToken cancellationToken = default);
    Task AddCommentAsync(int id, Comment comment, CancellationToken cancellationToken = default);
}
