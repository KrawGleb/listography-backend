using iLearning.Listography.DataAccess.Models.Common;

namespace iLearning.Listography.DataAccess.Interfaces.Services.Elastic;

public interface IElasticService
{
    Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value);
    Task<string> IndexItemAsync(SearchItem item);
    Task DeleteItemAsync(int id);
    Task UpdateItemAsync(SearchItem item);
}