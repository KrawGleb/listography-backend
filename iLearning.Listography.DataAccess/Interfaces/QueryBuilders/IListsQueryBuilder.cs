using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
public interface IListsQueryBuilder
{
    IListsQueryBuilder AsNoTracking(bool asNoTracking = true);
    IListsQueryBuilder IncludeItems(bool includeItems = true);
    IListsQueryBuilder IncludeItemTemplate(bool includeItemTemplate = true);
    IListsQueryBuilder IncludeTopic(bool includeTopic = true);
    IQueryable<UserList> Build();
}