using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Response>
{
    private readonly IListsRepository _listsRepository;
    private readonly IElasticService _elasticService;
    private readonly IMapper _mapper;

    public AddItemCommandHandler(
        IListsRepository listsRepository,
        IElasticService elasticService,
        IMapper mapper)
    {
        _listsRepository = listsRepository;
        _elasticService = elasticService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var item = await AddItemToList(request, cancellationToken);

        await IndexItemForSearch(item);

        return new CommonResponse
        {
            Succeeded = true,
            Body = item
        };
    }

    private async Task<ListItem> AddItemToList(AddItemCommand request, CancellationToken cancellationToken = default)
    {
        var item = _mapper.Map<ListItem>(request);
        await _listsRepository.AddItemToListAsync(request.ListId, item, cancellationToken);

        return item;
    }

    private async Task IndexItemForSearch(ListItem item)
    {
        var searchItem = _mapper.Map<SearchItem>(item);
        await _elasticService.IndexItemAsync(searchItem);
    }
}
