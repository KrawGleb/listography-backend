using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Common.Extensions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Common.List;
using iLearning.Listography.Application.Models.ViewModels.List;
using iLearning.Listography.Application.Requests.Items.Queries.Get;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Items.QueryHandlers;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, Response>
{
    private readonly IItemsRepository _repository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;

    public GetItemQueryHandler(
        IItemsRepository repository,
        IHttpContextAccessor contextAccessor,
        IMapper mapper)
    {
        _repository = repository;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken)
            ?? throw new NotFoundException($"Item with id {request.Id} not found.");
        
        var itemModel = _mapper.Map<ItemViewModel>(item);
        itemModel.Comments = _mapper.Map<ICollection<CommentViewModel>>(item.Comments);
        itemModel.Liked = item?.Likes?.Any(l => l.ApplicationUserId == userId);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = itemModel
        };
    }
}
