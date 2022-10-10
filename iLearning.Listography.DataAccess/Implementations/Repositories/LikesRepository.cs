using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

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
                e.AccountId == userId)
            .Single();

        if (entity is not null)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
