using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
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

public class CreateListCommandHandler : IRequestHandler<CreateListCommand, Response>
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IListsRepository _repository;
    private readonly ITopicsRepository _topicsRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public CreateListCommandHandler(
        IMapper mapper,
        UserManager<ApplicationUser> userManager,
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

    public async Task<Response> Handle(CreateListCommand request, CancellationToken cancellationToken)
    {
        await CreateList(request, cancellationToken);

        return new Response() { Succeeded = true };
    }

    private async Task CreateList(CreateListCommand request, CancellationToken cancellationToken = default)
    {
        var userId = _contextAccessor.HttpContext.GetUserId();
        var listOwner = await GetListOwnerAsync(userId, cancellationToken);

        var list = _mapper.Map<UserList>(request);
        list.Topic = await _topicsRepository.GetTopicByNameAsync(request.Topic?.Name!, cancellationToken);

        listOwner.Lists!.Add(list);

        await _repository.CreateAsync(list, cancellationToken);
        await _userManager.UpdateAsync(listOwner);
    }

    private async Task<ApplicationUser> GetListOwnerAsync(string id, CancellationToken cancellationToken)
    {
        var listOwner = await _userManager
            .Users
            .Include(u => u.Lists)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken)
        ?? throw new NotFoundException("Invalid user id.");

        return listOwner;
    }
}
