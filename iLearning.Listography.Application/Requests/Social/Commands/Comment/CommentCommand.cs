using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Social.Commands.Comment;

public class CommentCommand : IRequest<Response>
{
    public int ItemId { get; set; }
    public string? Content { get; set; }
}
