using iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
using iLearning.Listography.DataAccess.Models.List;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.DataAccess.Implementations.QueryBuilders;

public class ItemsQueryBuilder : IItemsQueryBuilder
{
	private readonly DbSet<ListItem> _table;
	private IQueryable<ListItem> _query;

	public ItemsQueryBuilder(ApplicationDbContext context)
	{
		_table = context.Set<ListItem>();
		_query = _table;
	}

	public IItemsQueryBuilder Track(bool track = false)
	{
		_query = track
			? _query
			: _query.AsNoTracking();

		return this;
	}

	public IItemsQueryBuilder IncludeCustomFields()
	{
		_query = _query
			.Include(i => i.CustomFields);

		return this;
	}

	public IItemsQueryBuilder IncludeComments()
	{
		_query = _query
			.Include(i => i.Comments)!
			.ThenInclude(c => c.ApplicationUser);

		return this;
	}

	public IItemsQueryBuilder IncludeTags()
	{
		_query = _query.Include(i => i.Tags);

		return this;
	}

	public IItemsQueryBuilder IncludeLikes()
	{
		_query = _query.Include(i => i.Likes);

		return this;
	}

	public IQueryable<ListItem> Build()
	{
		var query = _query;

		_query = _table;

		return query;
	}
}
