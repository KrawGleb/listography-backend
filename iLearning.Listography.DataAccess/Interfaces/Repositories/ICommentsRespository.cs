using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ICommentsRespository : IEFRepository<Comment>
{
    Task<IEnumerable<Comment>> GetItemCommentsAsync(
        int itemId,
        bool trackEntities = false,
        CancellationToken cancellationToken = default);
}
