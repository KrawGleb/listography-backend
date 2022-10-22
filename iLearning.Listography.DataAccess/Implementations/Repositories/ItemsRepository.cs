using iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ItemsRepository : EFRepository<ListItem>, IItemsRepository
{
    private readonly IItemsQueryBuilder _queryBuilder;
    private readonly ICustomFieldsRepository _customFieldsRepository;
    private readonly ITagsRepository _tagsRepository;

    public ItemsRepository(
        ApplicationDbContext context,
        IItemsQueryBuilder queryBuilder,
        ICustomFieldsRepository customFieldsRepository,
        ITagsRepository tagsRepository)
        : base(context)
    {
        _queryBuilder = queryBuilder;
        _customFieldsRepository = customFieldsRepository;
        _tagsRepository = tagsRepository;
    }

    public async override Task<ListItem> CreateAsync(ListItem entity, CancellationToken cancellationToken = default)
    {
        await _customFieldsRepository.AddRangeAsync(entity.CustomFields, cancellationToken);
        await _tagsRepository.CreateTagsAsync(entity.Tags, cancellationToken);

        entity.CreatedAt = DateTime.Now;

        return entity;
    }

    public async override Task<ListItem?> GetByIdAsync(
        int id,
        bool trackEntity = false,
        CancellationToken cancellationToken = default)
    {
        var query = _queryBuilder
            .AsNoTracking(trackEntity)
            .IncludeCustomFields()
            .IncludeTags()
            .IncludeComments()
            .IncludeLikes()
            .Build();

        var entity = await query
            .SingleOrDefaultAsync(i => i.Id == id, cancellationToken);

        return entity;
    }

    public async Task<int?> GetListIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var item = await _table
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id == id, cancellationToken);

        return item?.UserListId;
    }

    public async Task<IEnumerable<ListItem>> GetLastCreatedAsync(int count, CancellationToken cancellationToken = default)
    {
        var query = _table
            .AsNoTracking()
            .Include(i => i.UserList)
                .ThenInclude(l => l!.ApplicationUser)
            .OrderByDescending(i => i.CreatedAt)
            .Take(count);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(ListItem oldEntity, ListItem newEntity, CancellationToken cancellationToken = default)
    {
        var updatedCustomFields = await _customFieldsRepository.UpdateCustomFieldsAsync(
            oldEntity.CustomFields,
            newEntity.CustomFields,
            cancellationToken);
        var updatedTags = await _tagsRepository.UpdateTagsAsync(
            oldEntity.Tags,
            newEntity.Tags,
            cancellationToken);

        oldEntity.Name = newEntity.Name;
        oldEntity.CustomFields = updatedCustomFields.ToList();
        oldEntity.Tags = updatedTags.ToList();

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddLikeAsync(int id, Like like, CancellationToken cancellationToken = default)
    {
        var entity = _table
            .Include(i => i.Likes)
            .Single(i => i.Id == id);

        entity.Likes!.Add(like);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddCommentAsync(int id, Comment comment, CancellationToken cancellationToken = default)
    {
        var entity = _table
            .Include(i => i.Comments)
            .Single(i => i.Id == id);

        entity.Comments!.Add(comment);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
