using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.List.Queries.Get;
using iLearning.Listography.DataAccess.Helpers.Options;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.List.QueryHandlers;

public class GetListQueryHandler : IRequestHandler<GetListQuery, Response>
{
    private readonly IListsRepository _repository;

    public GetListQueryHandler(IListsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var queryOptions = (ListQueryOptions options) =>
        {
            options.Id = request.Id;
            options.IncludeItems = true;
            options.IncludeItemTemplate = true;
            options.IncludeTopic = true;
        };

        var list = await _repository.GetByIdAsync(queryOptions, cancellationToken: cancellationToken);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = list
        };
    }
}
