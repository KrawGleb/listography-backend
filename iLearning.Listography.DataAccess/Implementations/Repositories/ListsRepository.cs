using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly ITagsRepository _tagsRepository;
    private readonly ICustomFieldsRepository _customFieldsRepository;
    private readonly ITopicsRepository _topicsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        ITagsRepository tagsRepository,
        ICustomFieldsRepository customFieldsRepository,
        ITopicsRepository topicsRepository)
        : base(context)
    {
        _tagsRepository = tagsRepository;
        _customFieldsRepository = customFieldsRepository;
        _topicsRepository = topicsRepository;
    }

    public async Task<UserList?> GetByIdAsync(
        int id,
        bool includeItems = true,
        bool includeItemTemplate = true,
        bool includeTopic = true,
        bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        query = includeItems
            ? query
                .Include(l => l.Items).ThenInclude(i => i.CustomFields)
                .Include(l => l.Items).ThenInclude(i => i.Tags)
            : query;

        query = includeItemTemplate
            ? query.Include(l => l.ItemTemplate).ThenInclude(i => i.CustomFields)
            : query;

        query = includeTopic
            ? query.Include(l => l.Topic)
            : query;

        return await query.FirstAsync(l => l.Id == id);
    }

    public async override Task UpdateAsync(UserList entity)
    {
        var existingList = await GetByIdAsync(
            entity.Id,
            includeItems: false,
            includeItemTemplate: false,
            trackEntity: true);

        if (existingList is null)
        {
            throw new InvalidOperationException();
        }

        await ApplyFieldsChangesAsync(existingList, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ListItem> AddItemToListAsync(int id, ListItem item)
    {
        var list = await GetByIdAsync(id, trackEntity: true);

        if (list is null)
        {
            throw new InvalidOperationException();
        }

        // TODO: Fix it.
        var customFields = item.CustomFields.Select(field =>
        {
            field.Id = 0;
            return field;
        });

        await _customFieldsRepository.AddRangeAsync(customFields);
        await _tagsRepository.CreateTags(item.Tags);

        list.Items!.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async override Task DeleteAsync(int id)
    {
        var list = await GetByIdAsync(id, true, true, true, true);
        _table.Remove(list);
        await _context.SaveChangesAsync();
    }

    private async Task ApplyFieldsChangesAsync(UserList oldEntity, UserList newEntity)
    {
        oldEntity.Title = newEntity.Title;
        oldEntity.Description = newEntity.Description;
        oldEntity.ImageUrl = newEntity.ImageUrl;
        oldEntity.Topic = await _topicsRepository.GetTopicByNameAsync(newEntity.Topic?.Name!);
    }
}
