using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.RemoveAdmin;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class RemoveAdminCommandHandler : IRequestHandler<RemoveAdminCommand, Response>
{
    private readonly UserManager<Account> _userManager;

    public RemoveAdminCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(RemoveAdminCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        await _userManager.RemoveFromRoleAsync(user, RolesEnum.Admin);

        return new Response { Succeeded = true };
    }
}
