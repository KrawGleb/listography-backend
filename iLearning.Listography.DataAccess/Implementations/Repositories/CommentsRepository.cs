using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class CommentsRepository : EFRepository<Comment>, ICommentsRespository
{
    public CommentsRepository(ApplicationDbContext context) 
        : base(context)
    { }

    public async Task<IEnumerable<Comment>> GetItemCommentsAsync(int itemId, bool trackEntities = false)
    {
        var query = trackEntities
            ? _table
            : _table.AsNoTracking();

        return await query
            .Include(i => i.ApplicationUser)
            .Where(i => i.ListItemId == itemId)
            .ToListAsync();
    }
}
