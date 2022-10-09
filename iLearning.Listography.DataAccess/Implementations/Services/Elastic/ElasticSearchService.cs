using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.Constants;
using Nest;

namespace iLearning.Listography.DataAccess.Implementations.Services.Elastic;

public class ElasticSearchService : IElasticSearchService
{
    private readonly IElasticClient _client;

    public ElasticSearchService(IElasticClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value)
    {
        var response = await _client.SearchAsync<SearchItem>(s =>
            s.Index(ElasticConstants.ItemIndexName)
            .Query(q => q.QueryString(q => q.Query(value))));

        var items = response?.Documents.ToList();
        return items;
    }

    public async Task<string> IndexItemAsync(SearchItem item)
    {
        var response = await _client.IndexAsync(item, x => x.Index(ElasticConstants.ItemIndexName));

        return response.Id;
    }

    public async Task DeleteItemAsync(int id)
    {
        await _client.DeleteAsync<SearchItem>(id.ToString());
    }
}
