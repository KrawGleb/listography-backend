using iLearning.Listography.Application.Common.Extensions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Social.Commands.Comment;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Social.CommandHandlers;

public class CommentCommandHandler : IRequestHandler<CommentCommand, Response>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IItemsRepository _itemsRepository;

    public CommentCommandHandler(
        IHttpContextAccessor contextAccessor,
        IItemsRepository itemsRepository)
    {
        _contextAccessor = contextAccessor;
        _itemsRepository = itemsRepository;
    }

    public async Task<Response> Handle(CommentCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var comment = new Comment { ApplicationUserId = userId, Text = request.Content };

        await _itemsRepository.AddCommentAsync(request.ItemId, comment, cancellationToken);

        return new Response { Succeeded = true };
    }
}
