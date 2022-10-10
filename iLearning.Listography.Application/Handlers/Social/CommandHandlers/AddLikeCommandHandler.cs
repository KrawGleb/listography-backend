using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Social.Commands.AddLike;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Social.CommandHandlers;

public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, Response>
{
    private readonly ILikesRepository _repository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddLikeCommandHandler(
        ILikesRepository repository,
        IHttpContextAccessor contextAccessor)
    {
        _repository = repository;
        _contextAccessor = contextAccessor;
    }

    public async Task<Response> Handle(AddLikeCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var like = new Like
        {
            AccountId = userId,
            ListItemId = request.ItemId,
        };

        await _repository.CreateAsync(like);

        return new Response { Succeeded = true };
    }
}
