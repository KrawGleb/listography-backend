using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Common.List;
using iLearning.Listography.Application.Requests.Social.Queries.GetComments;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Social.QueryHandlers;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Response>
{
    private readonly ICommentsRespository _commentsRespository;
    private readonly IMapper _mapper;

    public GetCommentsQueryHandler(
        ICommentsRespository commentsRespository,
        IMapper mapper)
    {
        _commentsRespository = commentsRespository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentsRespository.GetItemCommentsAsync(request.ItemId);
        var commentModels = _mapper.Map<ICollection<CommentViewModel>>(comments);
        
        return new CommonResponse
        {
            Succeeded = true,
            Body = commentModels
        };
    }
}
