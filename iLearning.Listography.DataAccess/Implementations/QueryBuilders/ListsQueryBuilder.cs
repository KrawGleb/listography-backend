using iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.QueryBuilders;

public class ListsQueryBuilder : IListsQueryBuilder
{
    private readonly DbSet<UserList> _table;
    private IQueryable<UserList> _query;

    public ListsQueryBuilder(ApplicationDbContext context)
    {
        _table = context.Set<UserList>();
        _query = _table;
    }

    public IListsQueryBuilder Track(bool track = false)
    {
        _query = track
             ? _query
             : _query.AsNoTracking();

        return this;
    }

    public IListsQueryBuilder IncludeItems(bool includeItems = true)
    {
        _query = includeItems
            ? _query
                .Include(l => l.Items!)
                    .ThenInclude(i => i.CustomFields)
                .Include(l => l.Items!).ThenInclude(i => i.Tags)
            : _query;

        return this;
    }

    public IListsQueryBuilder IncludeItemTemplate(bool includeItemTemplate = true)
    {
        _query = includeItemTemplate
            ? _query
                .Include(l => l.ItemTemplate!)
                    .ThenInclude(i => i.CustomFields)!
                    .ThenInclude(f => f.SelectOptions)
            : _query;

        return this;
    }

    public IListsQueryBuilder IncludeTopic(bool includeTopic = true)
    {
        _query = includeTopic
            ? _query.Include(l => l.Topic)
            : _query;

        return this;
    }

    public IQueryable<UserList> Build()
    {
        var query = _query;

        _query = _table;

        return query;
    }
}
