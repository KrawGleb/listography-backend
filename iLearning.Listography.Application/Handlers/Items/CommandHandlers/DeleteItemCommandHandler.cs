using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Delete;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Response>
{
    private readonly IItemsRepository _repository;
    private readonly IElasticService _elasticService;

    public DeleteItemCommandHandler(
        IItemsRepository repository,
        IElasticService elasticService)
    {
        _repository = repository;
        _elasticService = elasticService;
    }

    public async Task<Response> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        await _elasticService.DeleteItemAsync(request.Id);

        return new Response()
        {
            Succeeded = true
        };
    }
}
