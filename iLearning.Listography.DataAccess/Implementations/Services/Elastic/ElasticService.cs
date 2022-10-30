using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.Constants;
using Nest;

namespace iLearning.Listography.DataAccess.Implementations.Services.Elastic;

public class ElasticService : IElasticService
{
    private readonly IElasticClient _client;

    public ElasticService(IElasticClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<SearchItem>?> SearchByValueAsync(string value, CancellationToken cancellationToken = default)
        => (await _client.SearchAsync<SearchItem>(s =>
                s.Index(ElasticConstants.ItemIndexName)
                .Query(q => q.QueryString(q => q.Query($"*{value}*"))), cancellationToken)).Documents;

    public async Task<IndexResponse> IndexItemAsync(SearchItem item, CancellationToken cancellationToken = default)
        => await _client
            .IndexAsync(
                item, x => x.Index(ElasticConstants.ItemIndexName), cancellationToken);

    public async Task UpdateItemAsync(SearchItem item, CancellationToken cancellationToken = default)
        => await _client
            .UpdateAsync<SearchItem>(
                item.Id, u => u.Index(ElasticConstants.ItemIndexName).Doc(item), cancellationToken);

    public async Task DeleteItemAsync(int id, CancellationToken cancellationToken = default)
        => await _client.DeleteAsync<SearchItem>(id.ToString(), ct: cancellationToken);

    public async Task DeleteListAsync(int listId, CancellationToken cancellationToken = default)
        => await _client.DeleteByQueryAsync<SearchItem>(q =>
            q.Query(rq => rq.Match(m => m.Field(f => f.ListId).Query(listId.ToString()))), cancellationToken);

    public async Task DeleteUserAsync(string userId, CancellationToken cancellationToken = default)
        => await _client.DeleteByQueryAsync<SearchItem>(q =>
            q.Query(rq => rq.Match(m => m.Field(f => f.AuthorId).Query(userId))), cancellationToken);
}
