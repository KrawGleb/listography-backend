using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Identity.CommandHandlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterCommandHandler(
        UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await RegisterUserAsync(request);

        return result.Succeeded
            ? new Response() { Succeeded = true }
            : new ErrorResponse() { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
    }

    private async Task<IdentityResult> RegisterUserAsync(RegisterCommand request)
    {
        var user = new ApplicationUser()
        {
            UserName = request.Username,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        return result;
    }
}
