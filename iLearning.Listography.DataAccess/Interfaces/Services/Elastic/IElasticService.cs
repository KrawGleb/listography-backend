using iLearning.Listography.DataAccess.Models.Common;
using Nest;

namespace iLearning.Listography.DataAccess.Interfaces.Services.Elastic;

public interface IElasticService
{
    Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value);
    Task<IndexResponse> IndexItemAsync(SearchItem item);
    Task DeleteItemAsync(int id);
    Task UpdateItemAsync(SearchItem item);
}