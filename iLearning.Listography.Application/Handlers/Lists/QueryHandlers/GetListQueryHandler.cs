using iLearning.Listography.Application.Requests.List.Queries.Get;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.List.QueryHandlers;

public class GetListQueryHandler : IRequestHandler<GetListQuery, UserList?>
{
    private readonly IListsRepository _repository;

    public GetListQueryHandler(IListsRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserList?> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
