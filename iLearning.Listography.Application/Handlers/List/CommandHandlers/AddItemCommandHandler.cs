using AutoMapper;
using iLearning.Listography.Application.Requests.List.Commands.AddItem;
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
    private readonly IMapper _mapper;

    public AddItemCommandHandler(
        IHttpContextAccessor contextAccessor,
        UserManager<Account> userManager,
        IMapper mapper)
    {
        _contextAccessor = contextAccessor;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var user = await _userManager
            .Users
            .Include(u => u.Lists)
            .ThenInclude(l => l.Items)
            .FirstOrDefaultAsync(u => u.Id == userId);

        var item = _mapper.Map<ListItem>(request);

        var list = user.Lists?.FirstOrDefault(l => l.Id == request.ListId);

        if (list is not null)
        {
            list.Items?.Add(item);
            await _userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}
