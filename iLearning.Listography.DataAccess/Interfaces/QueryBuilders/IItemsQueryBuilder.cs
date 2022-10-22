using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
public interface IItemsQueryBuilder
{
    IItemsQueryBuilder Track(bool track = false);
    IItemsQueryBuilder IncludeComments();
    IItemsQueryBuilder IncludeCustomFields();
    IItemsQueryBuilder IncludeLikes();
    IItemsQueryBuilder IncludeTags();
    IQueryable<ListItem> Build();
}