using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Lists.Commands.Delete;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Lists.CommandHandlers;

public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, Response>
{
    private readonly IListsRepository _repository;
    private readonly IElasticService _elasticService;

    public DeleteListCommandHandler(
        IListsRepository repository,
        IElasticService elasticService)
    {
        _repository = repository;
        _elasticService = elasticService;
    }

    public async Task<Response> Handle(DeleteListCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.ListId);

        // TODO: clear elastic search storage
        /*foreach (var deletedItem in deletedList?.Items!)
        {
            await _elasticService.DeleteItemAsync(deletedItem.Id);
        }*/

        return new Response() { Succeeded = true };
    }
}
