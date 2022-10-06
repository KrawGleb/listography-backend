using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.List.Queries.Get;
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
        var list = await _repository.GetByIdAsync(request.Id);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = list
        };
    }
}
