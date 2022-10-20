using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class LikesRepository : EFRepository<Like>, ILikesRepository
{
    public LikesRepository(ApplicationDbContext context) 
        : base(context)
    { }

    public async Task DeleteAsync(string userId, int itemId)
    {
        var entity = _table
            .Where(e =>
                e.ListItemId == itemId &&
                e.ApplicationUserId == userId)
            .SingleOrDefault();

        if (entity is not null)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckIfExsistsAsync(string userId, int itemId)
    {
        var entity = await _table
            .Where(e =>
                e.ListItemId == itemId &&
                e.ApplicationUserId == userId)
            .SingleOrDefaultAsync();

        return entity is not null;
    }
}
