using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Delete;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Response>
{
    private readonly IItemsRepository _repository;
    private readonly IElasticSearchService _elasticSearchService;

    public DeleteItemCommandHandler(
        IItemsRepository repository,
        IElasticSearchService elasticSearchService)
    {
        _repository = repository;
        _elasticSearchService = elasticSearchService;
    }

    public async Task<Response> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        await _elasticSearchService.DeleteItemAsync(request.Id);

        return new Response()
        {
            Succeeded = true
        };
    }
}
