using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Response>
{
    public string? Username { get; set; }
}
