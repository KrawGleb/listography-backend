using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Commands.UnblockUser;

public class UnblockUserCommand : IRequest<Response>
{
    public string? Username { get; set; }
}
