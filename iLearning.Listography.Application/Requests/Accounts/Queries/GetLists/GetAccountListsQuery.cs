using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;

public class GetAccountListsQuery : IRequest<Response>
{
    public string? Username { get; set; }
}
