using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;

public class GetAccountListsQuery : IRequest<IEnumerable<UserList>?>
{
    public string? Username { get; set; }
}
