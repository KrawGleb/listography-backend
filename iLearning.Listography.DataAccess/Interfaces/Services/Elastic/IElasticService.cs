using iLearning.Listography.DataAccess.Models.Common;
using Nest;

namespace iLearning.Listography.DataAccess.Interfaces.Services.Elastic;

public interface IElasticService
{
    Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value, CancellationToken cancellationToken = default);
    Task<IndexResponse> IndexItemAsync(SearchItem item, CancellationToken cancellationToken = default);
    Task DeleteItemAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateItemAsync(SearchItem item, CancellationToken cancellationToken = default);
}