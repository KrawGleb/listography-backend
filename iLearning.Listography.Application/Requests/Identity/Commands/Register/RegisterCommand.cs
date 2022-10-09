using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;

public class RegisterCommand : IRequest<Response>
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
