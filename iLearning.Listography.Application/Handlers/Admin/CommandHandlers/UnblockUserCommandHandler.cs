using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.UnblockUser;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class UnblockUserCommandHandler : IRequestHandler<UnblockUserCommand, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UnblockUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(UnblockUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        user.State = UserState.Avaliable;

        await _userManager.UpdateAsync(user);

        return new Response { Succeeded = true };
    }
}
