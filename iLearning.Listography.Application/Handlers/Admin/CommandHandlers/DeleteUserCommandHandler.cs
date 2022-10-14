using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response>
{
    private readonly UserManager<Account> _userManager;

    public DeleteUserCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var query = await _userManager
            .Users
            .Include(u => u.Lists)
            .Include(u => u.Comments)
            .Include(u => u.Likes)
            .FirstOrDefaultAsync(a => a.UserName == request.Username);

        await _userManager.DeleteAsync(query);

        return new Response { Succeeded = true };
    }
}
