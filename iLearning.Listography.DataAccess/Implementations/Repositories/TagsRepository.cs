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
        if (tags is null)
            return tags;

        tags = tags.Select(tag =>
        {
            tag.Id = 0;
            return tag;
        });

        await _table.AddRangeAsync(tags);

        return tags;
    }

    public async Task DeleteAll(IEnumerable<ListTag>? tags)
    {
        if (tags is not null)
        {
            _table.RemoveRange(tags);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ListTag>?> UpdateTagsAsync(IEnumerable<ListTag>? oldTags, IEnumerable<ListTag>? newTags)
    {
        if (oldTags is null || newTags is null)
        {
            return newTags;
        }

        var existingTags = oldTags.Where(tag => newTags.Any(t => t.Name == tag.Name));
        var notExistingTags = newTags.Where(tag => existingTags.All(t => t.Name != tag.Name));

        await _table.AddRangeAsync(notExistingTags);
        await _context.SaveChangesAsync();

        return existingTags.Concat(notExistingTags);
    }

    public async Task<IEnumerable<ListTag>> GetRandomAsync(int count)
    {
        return await _table
            .AsNoTracking()
            .Select(t => t.Name)
            .Distinct()
            .OrderBy(i => Guid.NewGuid())
            .Take(count)
            .Select(n => new ListTag { Name = n })
            .ToListAsync();
    }
}
