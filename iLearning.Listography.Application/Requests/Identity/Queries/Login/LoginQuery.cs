using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Identity.Queries.Login;

public class LoginQuery : IRequest<Response>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
