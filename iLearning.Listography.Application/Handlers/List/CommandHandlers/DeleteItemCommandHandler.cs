using iLearning.Listography.Application.Requests.List.Commands.DeleteItem;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IItemsRepository _repository;
    private readonly IUserPermissionsService _userPermissionsService;
    private readonly IHttpContextAccessor _contextAccessor;

    public DeleteItemCommandHandler(
        IItemsRepository repository,
        IUserPermissionsService userPermissionsService,
        IHttpContextAccessor contextAccessor)
    {
        _repository = repository;
        _userPermissionsService = userPermissionsService;
        _contextAccessor = contextAccessor;
    }

    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id);
        var userId = _contextAccessor.HttpContext.GetUserId();

        if (item is not null &&
            await _userPermissionsService.AllowEditListAsync(userId, item.UserListId))
        {
            await _repository.DeleteAsync(request.Id);
        }
        else
        {
            throw new InvalidOperationException();
        }

        return Unit.Value;
    }
}
