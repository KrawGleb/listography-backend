using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class TagsRepository : EFRepository<ListTag>, ITagsRepository
{
    public TagsRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<IEnumerable<ListTag>?> CreateTagsAsync(IEnumerable<ListTag>? tags)
    {
        if (tags is not null)
        {
            await _table.AddRangeAsync(tags);
        }

        return tags;
    }

    public void DeleteAll(IEnumerable<ListTag>? tags)
    {
        if (tags is not null)
        {
            _table.RemoveRange(tags);
        }
    }

    public async Task<IEnumerable<ListTag>> GetRandomAsync(int count)
    {
        return await _table
            .Select(t => t.Name)
            .Distinct()
            .OrderBy(i => Guid.NewGuid())
            .Take(count)
            .Select(n => new ListTag { Name = n})
            .ToListAsync();
    }
}
