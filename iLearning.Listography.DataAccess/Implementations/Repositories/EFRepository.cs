using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class EFRepository<T> : IEFRepository<T> 
    where T : class, IEntity, new()
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(bool trackEntities = false)
    {
        var query = trackEntities
            ? _table
            : _table.AsNoTracking();

        return await query.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id, bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        return await query.FirstOrDefaultAsync(t => t.Id == id);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _table.AddRangeAsync(entities);

        await _context.SaveChangesAsync();
    }


    public virtual async Task CreateAsync(T entity)
    {
        await _table.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public virtual void Update(T entity) => _table.Update(entity);

    public virtual async Task DeleteAsync(T entity)
    {
        _table.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = _context
            .ChangeTracker
            .Entries<T>()
            .FirstOrDefault(entry => entry.Entity.Id == id)?
            .Entity;

        entity ??= new T { Id = id };

        _table.Remove(entity);

        await _context.SaveChangesAsync();
    }
}
