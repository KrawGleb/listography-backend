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
        await _repository.DeleteAsync(request.ListId, cancellationToken);
        await _elasticService.DeleteListAsync(request.ListId);

        return new Response() { Succeeded = true };
    }
}
