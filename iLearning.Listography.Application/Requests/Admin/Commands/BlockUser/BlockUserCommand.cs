using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Commands.BlockUser;

public class BlockUserCommand : IRequest<Response>
{
    public string? Username { get; set; }
}
