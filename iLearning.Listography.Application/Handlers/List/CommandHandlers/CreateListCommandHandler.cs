using AutoMapper;
using iLearning.Listography.Application.Requests.List.Commands.Create;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class CreateListCommandHandler : IRequestHandler<CreateListCommand>
{
    private readonly IMapper _mapper;
    private readonly UserManager<Account> _userManager;
    private readonly IListsRepository _repository;

    public CreateListCommandHandler(
        IMapper mapper,
        UserManager<Account> userManager,
        IListsRepository repository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateListCommand request, CancellationToken cancellationToken)
    {
        var relatedUser = await _userManager
            .Users
            .Include(u => u.Lists)
            .FirstOrDefaultAsync(u => u.Id == request.UserId);
        var list = _mapper.Map<UserList>(request);

        relatedUser.Lists!.Add(list);

        await _repository.CreateAsync(list);
        await _userManager.UpdateAsync(relatedUser);

        return Unit.Value;
    }
}
