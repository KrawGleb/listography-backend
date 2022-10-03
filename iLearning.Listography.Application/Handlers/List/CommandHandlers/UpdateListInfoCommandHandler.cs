using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.List.Commands.UpdateInfo;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class UpdateListInfoCommandHandler : IRequestHandler<UpdateListInfoCommand, Response>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IListsRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUserPermissionsService _userPermissionsService;

    public UpdateListInfoCommandHandler(
        IUserPermissionsService userPermissionsService,
        IHttpContextAccessor contextAccessor,
        IListsRepository repository,
        IMapper mapper)
    {
        _contextAccessor = contextAccessor;
        _repository = repository;
        _mapper = mapper;
        _userPermissionsService = userPermissionsService;
    }

    public async Task<Response> Handle(UpdateListInfoCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var allowEditList = await _userPermissionsService.AllowEditListAsync(userId, request.ListId);
        if (!allowEditList)
        {
            return new ErrorResponse { Succeeded = false };
        }

        var listInfo = _mapper.Map<UserList>(request);
        _repository.UpdateAsync(listInfo);

        return new Response { Succeeded = true };
    }
}

