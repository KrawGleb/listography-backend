using iLearning.Listography.DataAccess.Helpers.Options;
using iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.Repositories;

public class ListsRepository : EFRepository<UserList>, IListsRepository
{
    private readonly IListsQueryBuilder _queryBuilder;
    private readonly ITopicsRepository _topicsRepository;

    public ListsRepository(
        ApplicationDbContext context,
        IListsQueryBuilder queryBuilder,
        ITopicsRepository topicsRepository)
        : base(context)
    {
        _queryBuilder = queryBuilder;
        _topicsRepository = topicsRepository;
    }

    public async Task<UserList?> GetByIdAsync(
        Action<ListQueryOptions>? setupQuery,
        CancellationToken cancellationToken = default)
    {
        var queryOptions = new ListQueryOptions();
        setupQuery?.Invoke(queryOptions);

        var query = _queryBuilder
            .Track(queryOptions.Track)
            .IncludeItems(queryOptions.IncludeItems)
            .IncludeItemTemplate(queryOptions.IncludeItemTemplate)
            .IncludeTopic(queryOptions.IncludeTopic)
            .Build();

        return await query.SingleOrDefaultAsync(l => l.Id == queryOptions.Id, cancellationToken);
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
        var queryOptions = (ListQueryOptions options) =>
        {
            options.Id = entity.Id;
            options.IncludeItems = false;
            options.IncludeItemTemplate = false;
            options.Track = true;
        };

        var existingList = await GetByIdAsync(queryOptions, cancellationToken: cancellationToken)
        ?? throw new InvalidOperationException();

        await ApplyFieldsChangesAsync(existingList, entity, cancellationToken);

        _context.Entry(existingList).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ListItem> AddItemToListAsync(int id, ListItem item, CancellationToken cancellationToken = default)
    {
        var queryOptions = (ListQueryOptions options) =>
        {
            options.Id = id;
            options.Track = true;
            options.IncludeItems = true;
        };

        var list = await GetByIdAsync(queryOptions, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException();

        item.CreatedAt = DateTime.UtcNow;
        list.Items!.Add(item);

        await _context.SaveChangesAsync(cancellationToken);

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
