using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Response>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IListsRepository _listsRepository;
    private readonly IUserPermissionsService _userPermissionsService;
    private readonly IMapper _mapper;

    public AddItemCommandHandler(
        IUserPermissionsService userPermissionsService,
        IHttpContextAccessor contextAccessor,
        IListsRepository listsRepository,
        IMapper mapper)
    {
        _userPermissionsService = userPermissionsService;
        _contextAccessor = contextAccessor;
        _listsRepository = listsRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();

        if (await _userPermissionsService.AllowEditListAsync(userId, request.ListId))
        {
            var item = _mapper.Map<ListItem>(request);
            await _listsRepository.AddItemToListAsync(request.ListId, item);

            return new CommonResponse
            {
                Succeeded = true,
                Body = item
            };
        }

        return new ErrorResponse
        {
            Succeeded = false,
        };
    }
}
