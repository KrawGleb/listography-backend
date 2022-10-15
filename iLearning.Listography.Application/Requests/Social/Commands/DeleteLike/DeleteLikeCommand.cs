using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Social.Commands.DeleteLike;

public class DeleteLikeCommand : IRequest<Response>
{
    public int ItemId { get; set; }
}
