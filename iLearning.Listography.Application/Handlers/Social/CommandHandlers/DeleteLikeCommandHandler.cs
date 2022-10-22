using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Social.Commands.DeleteLike;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Social.CommandHandlers;

public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, Response>
{
    private readonly ILikesRepository _repository;
    private readonly IHttpContextAccessor _contextAccessor;

    public DeleteLikeCommandHandler(
        ILikesRepository repository,
        IHttpContextAccessor contextAccessor)
    {
        _repository = repository;
        _contextAccessor = contextAccessor;
    }

    public async Task<Response> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();

        await _repository.DeleteAsync(userId, request.ItemId, cancellationToken);

        return new Response { Succeeded = true };
    }
}
