using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class TagsRepository : EFRepository<ListTag>, ITagsRepository
{
    public TagsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<IEnumerable<ListTag>> CreateTags(IEnumerable<ListTag> tags)
    {
        await _table.AddRangeAsync(tags);
        return tags;
    }

    public void DeleteAll(IEnumerable<ListTag> tags)
    {
        _table.RemoveRange(tags);
    }
}
