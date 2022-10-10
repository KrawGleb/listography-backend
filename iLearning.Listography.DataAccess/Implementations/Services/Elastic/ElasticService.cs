using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.Constants;
using Microsoft.Extensions.Logging;
using Nest;

namespace iLearning.Listography.DataAccess.Implementations.Services.Elastic;

public class ElasticService : IElasticService
{
    private readonly ILogger<ElasticService> _logger;
    private readonly IElasticClient _client;

    public ElasticService(ILogger<ElasticService> logger, IElasticClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value)
        => (await _client.SearchAsync<SearchItem>(s =>
            s.Index(ElasticConstants.ItemIndexName)
            .Query(q => q.QueryString(q => q.Query(value))))).Documents;

    public async Task<string> IndexItemAsync(SearchItem item)
    {
        var response = await _client.IndexAsync(item, x => x.Index(ElasticConstants.ItemIndexName));

        _logger.LogInformation("ElasticSearch responses with: ", response);

        return response.Id;
    }

    public async Task UpdateItemAsync(SearchItem item)
        => await _client
            .UpdateAsync<SearchItem>(
                item.Id, u => u.Index(ElasticConstants.ItemIndexName).Doc(item));

    public async Task DeleteItemAsync(int id)
        => await _client.DeleteAsync<SearchItem>(id.ToString());

}
