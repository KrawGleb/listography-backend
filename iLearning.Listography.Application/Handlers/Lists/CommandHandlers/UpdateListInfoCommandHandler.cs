using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Lists.Commands.Update;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class UpdateListInfoCommandHandler : IRequestHandler<UpdateListInfoCommand, Response>
{
    private readonly IListsRepository _repository;
    private readonly IMapper _mapper;

    public UpdateListInfoCommandHandler(
        IListsRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateListInfoCommand request, CancellationToken cancellationToken)
    {
        var listInfo = _mapper.Map<UserList>(request);
        await _repository.UpdateAsync(listInfo);

        return new Response { Succeeded = true };
    }
}

