using iLearning.Listography.Application.Requests.Identity.Commands.RegisterUser;
using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Identity.CommandHandlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IdentityResult>
{
    private readonly UserManager<Account> _userManager;
    private readonly ApplicationDbContext _context;

    public RegisterCommandHandler(
        UserManager<Account> userManager,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IdentityResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            UserName = request.Email,
            Email = request.Email,
        };

        return await _userManager.CreateAsync(account, request.Password);
    }
}
