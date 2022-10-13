using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Commands.Admin;

public class AppointAdminCommand : IRequest<Response>
{
    public string? Username { get; set; }
}
