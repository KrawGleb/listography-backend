using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // TODO: Review it.
        // Maybe we don't need to include related entities 'cause cascade delete was used
        var query = await _userManager
            .Users
            .Include(u => u.Lists)
            .Include(u => u.Comments)
            .Include(u => u.Likes)
            .FirstOrDefaultAsync(a => a.UserName == request.Username, cancellationToken: cancellationToken)
        ?? throw new NotFoundException("User not found");

        await _userManager.DeleteAsync(query);

        return new Response { Succeeded = true };
    }
}
