using AutoMapper;
using iLearning.Listography.Application.Requests.List.Commands.AddItem;
using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UserManager<Account> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IListsRepository _listsRepository;
    private readonly IMapper _mapper;

    public AddItemCommandHandler(
        IHttpContextAccessor contextAccessor,
        UserManager<Account> userManager,
        ApplicationDbContext context,
        IListsRepository listsRepository,
        IMapper mapper)
    {
        _contextAccessor = contextAccessor;
        _userManager = userManager;
        _context = context;
        _listsRepository = listsRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        if (!await CheckUserPermissionsAsync(request.ListId))
        {
            return Unit.Value;
        }

        var item = _mapper.Map<ListItem>(request);
        await _listsRepository.AddItemToListAsync(request.ListId, item);

        return Unit.Value;
    }

    // TODO: Check roles to.
    private async Task<bool> CheckUserPermissionsAsync(int listId)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var user = await _userManager
            .Users
            .Include(u => u.Lists)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return
            user is not null &&
            user.Lists.Any(l => l.Id == listId);

    }
}
