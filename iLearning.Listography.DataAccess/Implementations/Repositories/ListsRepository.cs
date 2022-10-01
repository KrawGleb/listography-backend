using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly ITagsRepository _tagsRepository;
    private readonly ICustomFieldsRepository _customFieldsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        ITagsRepository tagsRepository,
        ICustomFieldsRepository customFieldsRepository)
        : base(context)
    {
        _tagsRepository = tagsRepository;
        _customFieldsRepository = customFieldsRepository;
    }

    public override async Task CreateAsync(UserList entity)
    {
        await _tagsRepository.CreateTags(entity.Tags);

        await base.CreateAsync(entity);
    }

    public override async Task<UserList?> GetByIdAsync(int id, bool trackEntity = false)
    {
        return await _table
            .Include(l => l.Items)
                .ThenInclude(i => i.CustomFields)
            .Include(l => l.ItemTemplate)
                .ThenInclude(t => t.CustomFields)
            .Include(l => l.Tags)
            .FirstAsync(l => l.Id == id);
    }

    public async Task AddItemToListAsync(int id, ListItem item)
    {
        var list = await GetByIdAsync(id);

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
}
