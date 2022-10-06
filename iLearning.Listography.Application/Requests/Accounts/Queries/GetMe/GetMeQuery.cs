using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;

public class GetMeQuery : IRequest<Response>
{ 
    public string? Id { get; set; }
}
