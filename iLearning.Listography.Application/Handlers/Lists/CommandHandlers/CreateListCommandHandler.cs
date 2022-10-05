using AutoMapper;
using iLearning.Listography.Application.Requests.Lists.Commands.Create;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using iLearning.Listography.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class CreateListCommandHandler : IRequestHandler<CreateListCommand>
{
    private readonly IMapper _mapper;
    private readonly UserManager<Account> _userManager;
    private readonly IListsRepository _repository;
    private readonly ITopicsRepository _topicsRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public CreateListCommandHandler(
        IMapper mapper,
        UserManager<Account> userManager,
        IListsRepository repository,
        ITopicsRepository topicsRepository,
        IHttpContextAccessor contextAccessor)
    {
        _mapper = mapper;
        _userManager = userManager;
        _repository = repository;
        _topicsRepository = topicsRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<Unit> Handle(CreateListCommand request, CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();

        var relatedUser = await _userManager
            .Users
            .Include(u => u.Lists)
            .FirstOrDefaultAsync(u => u.Id == userId);

        var list = _mapper.Map<UserList>(request);
        list.Topic = await _topicsRepository.GetTopicByNameAsync(request.Topic?.Name!);

        relatedUser!.Lists!.Add(list);

        await _repository.CreateAsync(list);
        await _userManager.UpdateAsync(relatedUser);

        return Unit.Value;
    }
}
