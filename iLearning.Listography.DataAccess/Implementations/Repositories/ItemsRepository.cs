using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ItemsRepository : EFRepository<ListItem>, IItemsRepository
{
    private readonly ICustomFieldsRepository _customFieldsRepository;
    private readonly ITagsRepository _tagsRepository;

    public ItemsRepository(
        ApplicationDbContext context,
        ICustomFieldsRepository customFieldsRepository,
        ITagsRepository tagsRepository)
        : base(context)
    {
        _customFieldsRepository = customFieldsRepository;
        _tagsRepository = tagsRepository;
    }

    public async override Task<ListItem> CreateAsync(ListItem entity)
    {
        await _customFieldsRepository.AddRangeAsync(entity.CustomFields);
        await _tagsRepository.CreateTagsAsync(entity.Tags);

        entity.CreatedAt = DateTime.Now;

        return entity;
    }

    public async override Task<ListItem?> GetByIdAsync(int id, bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        var entity = await query
            .Include(i => i.CustomFields)!
                .ThenInclude(c => c.SelectOptions)
            .Include(i => i.Tags)
            .Include(i => i.Comments)!
                .ThenInclude(c => c.ApplicationUser)
            .Include(i => i.Likes)
            .SingleOrDefaultAsync(i => i.Id == id);

        return entity;
    }

    public async Task<int?> GetListIdAsync(int id)
    {
        var item = await _table
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id == id);

        return item?.UserListId;
    }

    public async Task<IEnumerable<ListItem>> GetLastCreated(int count)
    {
        var query = _table
            .AsNoTracking()
            .Include(i => i.UserList)
                .ThenInclude(l => l!.ApplicationUser)
            .OrderByDescending(i => i.CreatedAt)
            .Take(count);

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(ListItem oldEntity, ListItem newEntity)
    {
        var updatedCustomFields = await _customFieldsRepository.UpdateCustomFieldsAsync(oldEntity.CustomFields, newEntity.CustomFields);
        var updatedTags = await _tagsRepository.UpdateTagsAsync(oldEntity.Tags, newEntity.Tags);

        oldEntity.Name = newEntity.Name;
        oldEntity.CustomFields = updatedCustomFields.ToList();
        oldEntity.Tags = updatedTags.ToList();

        await _context.SaveChangesAsync();
    }

    public async Task AddLike(int id, Like like)
    {
        var entity = _table
            .Include(i => i.Likes)
            .Single(i => i.Id == id);

        entity.Likes!.Add(like);

        await _context.SaveChangesAsync();
    }

    public async Task AddComment(int id, Comment comment)
    {
        var entity = _table
            .Include(i => i.Comments)
            .Single(i => i.Id == id);

        entity.Comments!.Add(comment);

        await _context.SaveChangesAsync();
    }
}
