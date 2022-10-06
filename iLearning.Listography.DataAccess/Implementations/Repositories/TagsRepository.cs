using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;

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
}
