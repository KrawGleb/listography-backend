using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Search.Queries.Search;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Search.QueryHandlers;

public class SearchQueryHandler : IRequestHandler<SearchQuery, Response>
{
    private readonly IElasticSearchService _elasticSearchService;

    public SearchQueryHandler(IElasticSearchService elasticSearchService)
    {
        _elasticSearchService = elasticSearchService;
    }

    public async Task<Response> Handle(SearchQuery request, CancellationToken cancellationToken)
    {
        var items = await _elasticSearchService.SearchByValueAsync(request.SearchValue);

        return new CommonResponse
        {
            Succeeded = true,
            Body = items
        };
    }
}
