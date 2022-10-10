using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Social.Commands.AddLike;

public class AddLikeCommand : IRequest<Response>
{
    public int ItemId { get; set; }
}
