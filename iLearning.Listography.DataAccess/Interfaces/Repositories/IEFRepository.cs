using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;
public interface IEFRepository<T>
    where T : class, IEntity, new()
{
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(bool trackEntities = false, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, bool trackEntity = false, CancellationToken cancellationToken = default);
}