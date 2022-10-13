﻿using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Social.Commands.AddLike;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Social.CommandHandlers;

public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, Response>
{
    private readonly ILikesRepository _likesRepository;
    private readonly IItemsRepository _itemsRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddLikeCommandHandler(
        ILikesRepository likesRepository,
        IItemsRepository itemsRepository,
        IHttpContextAccessor contextAccessor)
    {
        _likesRepository = likesRepository;
        _itemsRepository = itemsRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<Response> Handle(AddLikeCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();

        var isExists = await _likesRepository.CheckIfExsists(userId, request.ItemId);

        if (isExists)
        {
            return new ErrorResponse()
            {
                Succeeded = false,
                Errors = new string[] { "User have already liked this item" }
            };
        }

        var like = new Like { AccountId = userId };

        await _itemsRepository.AddLike(request.ItemId, like);

        return new Response { Succeeded = true };
    }
}