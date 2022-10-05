using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Identity.CommandHandlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
{
    private readonly UserManager<Account> _userManager;

    public RegisterCommandHandler(
        UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            UserName = request.Username,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(account, request.Password);

        return result.Succeeded
            ? new Response() { Succeeded = true }
            : new ErrorResponse() { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
    }
}
