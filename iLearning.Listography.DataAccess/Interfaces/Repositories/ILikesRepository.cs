using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;

public interface ILikesRepository : IEFRepository<Like>
{
    Task DeleteAsync(string userId, int itemId);
    Task<bool> CheckIfExsists(string accountId, int itemId);
}
