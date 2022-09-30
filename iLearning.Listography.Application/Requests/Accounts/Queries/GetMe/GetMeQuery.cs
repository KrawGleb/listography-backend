using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;

public class GetMeQuery : IRequest<Account?>
{ 
    public string? Id { get; set; }
}
