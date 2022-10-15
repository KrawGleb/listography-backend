using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Response>
{
    private readonly IMapper _mapper;
    private readonly IItemsRepository _repository;
    private readonly IElasticService _elasticService;

    public UpdateItemCommandHandler(
        IMapper mapper,
        IItemsRepository repository,
        IElasticService elasticService)
    {
        _mapper = mapper;
        _repository = repository;
        _elasticService = elasticService;
    }

    public async Task<Response> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await UpdateItem(request);

        await UpdateItemForSearch(item);

        return new Response { Succeeded = true };
    }

    private async Task<ListItem> UpdateItem(UpdateItemCommand request)
    {
        var existingItem = await _repository.GetByIdAsync(request.Id, trackEntity: true)
            ?? throw new NotFoundException("Item not exists");

        var item = _mapper.Map<ListItem>(request);
        await _repository.UpdateAsync(existingItem, item);

        return item;
    }

    private async Task UpdateItemForSearch(ListItem item)
    {
        var elasticRecord = _mapper.Map<SearchItem>(item);
        await _elasticService.UpdateItemAsync(elasticRecord);
    }
}
