using iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly IListsQueryBuilder _queryBuilder;
    private readonly IItemsRepository _itemsRepository;
    private readonly ITopicsRepository _topicsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        IListsQueryBuilder queryBuilder,
        IItemsRepository itemsRepository,
        ITopicsRepository topicsRepository)
        : base(context)
    {
        _queryBuilder = queryBuilder;
        _itemsRepository = itemsRepository;
        _topicsRepository = topicsRepository;
    }

    public async Task<UserList?> GetByIdAsync(
        int id,
        bool includeItems = true,
        bool includeItemTemplate = true,
        bool includeTopic = true,
        bool trackEntity = false,
        CancellationToken cancellationToken = default)
    {
        var query = _queryBuilder
            .AsNoTracking(trackEntity)
            .IncludeItems(includeItems)
            .IncludeItemTemplate(includeItemTemplate)
            .IncludeTopic(includeTopic)
            .Build();

        return await query.SingleOrDefaultAsync(l => l.Id == id, cancellationToken);
    }

    public async Task<string?> GetOwnerIdAsync(int listId, CancellationToken cancellationToken = default)
    {
        var entity = await _table
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == listId, cancellationToken);

        return entity?.ApplicationUserId;
    }

    public async Task<IEnumerable<UserList>> GetLargestAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _table
            .AsNoTracking()
            .Include(l => l.Items)
            .OrderByDescending(l => l.Items!.Count)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(UserList entity, CancellationToken cancellationToken = default)
    {
        var existingList = await GetByIdAsync(
            entity.Id,
            includeItems: false,
            includeItemTemplate: false,
            trackEntity: true,
            cancellationToken: cancellationToken)
        ?? throw new InvalidOperationException();

        await ApplyFieldsChangesAsync(existingList, entity, cancellationToken);

        _context.Entry(existingList).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ListItem> AddItemToListAsync(int id, ListItem item, CancellationToken cancellationToken = default)
    {
        var list = await GetByIdAsync(id, trackEntity: true, cancellationToken)
            ?? throw new InvalidOperationException();

        await _itemsRepository.CreateAsync(item);

        list.Items!.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    private async Task ApplyFieldsChangesAsync(
        UserList oldEntity,
        UserList newEntity,
        CancellationToken cancellationToken = default)
    {
        oldEntity.Title = newEntity.Title;
        oldEntity.Description = newEntity.Description;
        oldEntity.ImageUrl = newEntity.ImageUrl;
        oldEntity.Topic = await _topicsRepository.GetTopicByNameAsync(newEntity.Topic?.Name!, cancellationToken);
    }
}
