using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Interfaces.QueryBuilders;
public interface IListsQueryBuilder
{
    IListsQueryBuilder Track(bool track = false);
    IListsQueryBuilder IncludeItems(bool includeItems = true);
    IListsQueryBuilder IncludeItemTemplate(bool includeItemTemplate = true);
    IListsQueryBuilder IncludeTopic(bool includeTopic = true);
    IQueryable<UserList> Build();
}