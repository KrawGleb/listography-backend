using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class EFRepository<T> : IEFRepository<T>
    where T : class, IEntity, new()
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _table;

    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(
        bool trackEntities = false,
        CancellationToken cancellationToken = default)
    {
        var query = trackEntities
            ? _table
            : _table.AsNoTracking();

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(
        int id,
        bool trackEntity = false,
        CancellationToken cancellationToken = default)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        return await query.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _table.AddRangeAsync(entities, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _table.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = _context
            .ChangeTracker
            .Entries<T>()
            .FirstOrDefault(entry => entry.Entity.Id == id)?
            .Entity;

        entity ??= new T { Id = id };

        _table.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
