using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Response>
{
    private readonly IMapper _mapper;
    private readonly IItemsRepository _repository;
    private readonly IUserPermissionsService _userPermissionsService;
    private readonly IHttpContextAccessor _contextAccessor;

    public UpdateItemCommandHandler(
        IMapper mapper,
        IItemsRepository repository,
        IUserPermissionsService userPermissionsService,
        IHttpContextAccessor contextAccessor)
    {
        _mapper = mapper;
        _repository = repository;
        _userPermissionsService = userPermissionsService;
        _contextAccessor = contextAccessor;
    }

    public async Task<Response> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var existingItem = await _repository.GetByIdAsync(request.Id, true);
        var userId = _contextAccessor.HttpContext.GetUserId();

        if (existingItem is not null &&
            await _userPermissionsService.AllowEditListAsync(userId, existingItem.UserListId))
        {
            var item = _mapper.Map<ListItem>(request);

            await _repository.UpdateAsync(existingItem, item);
        }
        else
        {
            throw new InvalidOperationException();
        }

        return new Response
        {
            Succeeded = true
        };
    }
}
