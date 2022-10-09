using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Lists.Commands.Delete;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Lists.CommandHandlers;

public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, Response>
{
    private readonly IListsRepository _repository;

    public DeleteListCommandHandler(IListsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(DeleteListCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.ListId);

        return new Response() { Succeeded = true };
    }
}
