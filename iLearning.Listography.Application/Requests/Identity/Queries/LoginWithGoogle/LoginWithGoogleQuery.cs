using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Identity.Queries.LoginWithGoogle;

public class LoginWithGoogleQuery : IRequest<Response>
{
    public string? IdToken { get; set; }
}
