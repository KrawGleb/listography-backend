using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Delete;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Response>
{
    private readonly IItemsRepository _repository;

    public DeleteItemCommandHandler(IItemsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);

        return new Response()
        {
            Succeeded = true
        };
    }
}
