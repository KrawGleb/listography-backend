using iLearning.Listography.DataAccess.Models.Interfaces;

namespace iLearning.Listography.DataAccess.Interfaces.Repositories;
public interface IEFRepository<T> 
    where T : class, IEntity, new()
{
    Task AddRangeAsync(IEnumerable<T> entities);
    Task CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool trackEntities = false);
    Task<T?> GetByIdAsync(int id, bool trackEntity = false);
    void Update(T entity);
}