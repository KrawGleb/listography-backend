﻿using AutoMapper;
using iLearning.Listography.Application.Models.Common.List;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Queries.Get;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.Infrastructure.Extensions;
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
        var item = await _repository.GetByIdAsync(request.Id);
        var itemModel = _mapper.Map<ItemModel>(item);

        itemModel.Comments = _mapper.Map<ICollection<CommentModel>>(item.Comments);
        itemModel.Liked = item?.Likes?.Any(l => l.AccountId == userId);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = itemModel
        };
    }
}
