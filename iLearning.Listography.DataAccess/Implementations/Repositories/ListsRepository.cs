using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

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

    public override async Task CreateAsync(UserList entity)
    {
        await _tagsRepository.CreateTags(entity.Tags);

        await base.CreateAsync(entity);
    }

    public async Task<UserList?> GetByIdAsync(
        int id, 
        bool includeItems = true, 
        bool includeTags = true, 
        bool includeItemTemplate = true,
        bool trackEntity = false)
    {
        var query = trackEntity
            ? _table
            : _table.AsNoTracking();

        query = includeItems
            ? query.Include(l => l.Items).ThenInclude(i => i.CustomFields)
            : query;

        query = includeItemTemplate
            ? query.Include(l => l.ItemTemplate).ThenInclude(i => i.CustomFields)
            : query;

        query = includeTags
            ? query.Include(l => l.Tags)
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

    public async Task AddItemToListAsync(int id, ListItem item)
    {
        var list = await GetByIdAsync(id, trackEntity: true);

        if (list is null)
        {
            return;
        }

        var customFields = item.CustomFields.Select(field =>
        {
            field.Id = 0;
            return field;
        });

        await _customFieldsRepository.AddRangeAsync(customFields);

        list.Items!.Add(item);

        await _context.SaveChangesAsync();
    }

    private async Task ApplyFieldsChangesAsync(UserList oldEntity, UserList updatedFields)
    {
        _tagsRepository.DeleteAll(oldEntity.Tags!);
        var newTags = await _tagsRepository.CreateTags(updatedFields.Tags!);

        oldEntity.Title = updatedFields.Title;
        oldEntity.Description = updatedFields.Description;
        oldEntity.Tags = newTags.ToList();
        oldEntity.ImageUrl = updatedFields.ImageUrl;
        oldEntity.Topic = await _topicsRepository.GetTopicByNameAsync(updatedFields.Topic?.Name);
    }
}
