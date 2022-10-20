using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Users.Queries.GetLists;

public class GetUserListsQuery : IRequest<Response>
{
    public string? Username { get; set; }
}
