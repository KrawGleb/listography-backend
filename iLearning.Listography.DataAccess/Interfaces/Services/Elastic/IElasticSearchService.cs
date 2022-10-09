using iLearning.Listography.DataAccess.Models.Common;

namespace iLearning.Listography.DataAccess.Interfaces.Services.Elastic;

public interface IElasticSearchService
{
    Task<string> IndexItemAsync(SearchItem item);
    Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value);
    Task DeleteItemAsync(int id);
}