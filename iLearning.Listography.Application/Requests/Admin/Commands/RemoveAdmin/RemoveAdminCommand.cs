using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Commands.RemoveAdmin;

public class RemoveAdminCommand : IRequest<Response>
{
    public string? Username { get; set; }
}
