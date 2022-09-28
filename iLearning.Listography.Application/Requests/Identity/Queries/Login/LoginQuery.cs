using MediatR;

namespace iLearning.Listography.Application.Requests.Identity.Queries.Login;

public class LoginQuery : IRequest<string>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
