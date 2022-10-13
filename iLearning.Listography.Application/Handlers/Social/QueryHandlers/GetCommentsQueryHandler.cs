using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Social.Queries.GetComments;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Social.QueryHandlers;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Response>
{
    private readonly ICommentsRespository _commentsRespository;

    public GetCommentsQueryHandler(ICommentsRespository commentsRespository)
    {
        _commentsRespository = commentsRespository;
    }

    public async Task<Response> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentsRespository.GetItemCommentsAsync(request.ItemId);

        return new CommonResponse
        {
            Succeeded = true,
            Body = comments
        };
    }
}
