using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Lists.Commands.Delete;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Lists.CommandHandlers;

public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, Response>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserPermissionsService _userPermissionsService;
    private readonly IListsRepository _repository;

    public DeleteListCommandHandler(
        IHttpContextAccessor contextAccessor,
        IUserPermissionsService userPermissionsService,
        IListsRepository repository)
    {
        _contextAccessor = contextAccessor;
        _userPermissionsService = userPermissionsService;
        _repository = repository;
    }

    public async Task<Response> Handle(DeleteListCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();

        if (await _userPermissionsService.AllowEditListAsync(userId, request.Id))
        {
            await _repository.DeleteAsync(request.Id);

            return new Response() { Succeeded = true };
        }

        return new ErrorResponse() { Succeeded = false };
    }
}
