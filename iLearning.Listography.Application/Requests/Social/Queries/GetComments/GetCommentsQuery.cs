using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Social.Queries.GetComments;

public class GetCommentsQuery : IRequest<Response>
{
    public int ItemId { get; set; }
}
