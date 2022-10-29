using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Commands.DeleteUser;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Admin.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IElasticService _elasticService;

    public DeleteUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        IElasticService elasticService)
    {
        _userManager = userManager;
        _elasticService = elasticService;
    }

    public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username)
            ?? throw new NotFoundException("User not found");

        await _userManager.DeleteAsync(user);
        await _elasticService.DeleteUserAsync(user.Id);

        return new Response { Succeeded = true };
    }
}
