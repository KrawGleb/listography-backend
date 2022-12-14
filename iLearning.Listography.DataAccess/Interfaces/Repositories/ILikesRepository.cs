using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ILikesRepository : IEFRepository<Like>
{
    Task DeleteAsync(string userId, int itemId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfExsistsAsync(string userId, int itemId, CancellationToken cancellationToken = default);
}
