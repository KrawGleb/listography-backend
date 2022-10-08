using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Queries.Get;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.QueryHandlers;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, Response>
{
    private readonly IItemsRepository _repository;

    public GetItemQueryHandler(IItemsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = item
        };
    }
}
