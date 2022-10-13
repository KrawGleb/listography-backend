using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.Admin;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class AppointAdminCommandHandler : IRequestHandler<AppointAdminCommand, Response>
{
    private readonly UserManager<Account> _userManager;

    public AppointAdminCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(AppointAdminCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        await _userManager.AddToRoleAsync(user, RolesEnum.Admin);

        return new Response { Succeeded = true };
    }
}
