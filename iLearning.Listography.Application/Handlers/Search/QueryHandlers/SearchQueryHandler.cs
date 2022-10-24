using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Search.Queries.Search;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Search.QueryHandlers;

public class SearchQueryHandler : IRequestHandler<SearchQuery, Response>
{
    private readonly IElasticService _elasticService;

    public SearchQueryHandler(IElasticService elasticService)
    {
        _elasticService = elasticService;
    }

    public async Task<Response> Handle(SearchQuery request, CancellationToken cancellationToken)
    {
        var items = await _elasticService.SearchByValueAsync(request.SearchValue, cancellationToken);

        return new CommonResponse
        {
            Succeeded = true,
            Body = items
        };
    }
}
