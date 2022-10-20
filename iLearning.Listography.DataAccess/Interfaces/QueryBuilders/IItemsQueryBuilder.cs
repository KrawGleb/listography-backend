using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
public interface IItemsQueryBuilder
{
    IItemsQueryBuilder AsNoTracking(bool asNoTracking = true);
    IItemsQueryBuilder IncludeComments();
    IItemsQueryBuilder IncludeCustomFields();
    IItemsQueryBuilder IncludeLikes();
    IItemsQueryBuilder IncludeTags();
    IQueryable<ListItem> Build();
}