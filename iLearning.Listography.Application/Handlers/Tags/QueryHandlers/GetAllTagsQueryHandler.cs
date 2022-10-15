using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Tags.Queries.GetAll;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Tags.QueryHandlers;

public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, Response>
{
    private readonly ITagsRepository _repository;

    public GetAllTagsQueryHandler(ITagsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _repository.GetAllAsync();

        return new CommonResponse
        {
            Succeeded = true,
            Body = tags
        };
    }
}
