using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Home;
using iLearning.Listography.Application.Requests.Home.Queries.Get;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Home.QueryHandlers;

public class GetHomeInfoQueryHandler : IRequestHandler<GetHomeInfoQuery, Response>
{
    private readonly IItemsRepository _itemsRepository;
    private readonly ITagsRepository _tagsRepository;
    private readonly IListsRepository _listsRepository;
    private readonly IMapper _mapper;

    public GetHomeInfoQueryHandler(
        IItemsRepository itemsRepository,
        ITagsRepository tagsRepository,
        IListsRepository listsRepository,
        IMapper mapper)
    {
        _itemsRepository = itemsRepository;
        _tagsRepository = tagsRepository;
        _listsRepository = listsRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetHomeInfoQuery request, CancellationToken cancellationToken)
    {
        var homeInfo = await GetHomeInfoAsync(request, cancellationToken);

        return new CommonResponse
        {
            Succeeded = true,
            Body = homeInfo
        };
    }

    private async Task<HomeViewModel> GetHomeInfoAsync(GetHomeInfoQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemsRepository.GetLastCreatedAsync(request.ItemsCount, cancellationToken);
        var tags = await _tagsRepository.GetRandomAsync(request.TagsCount, cancellationToken);
        var lists = await _listsRepository.GetLargestAsync(request.ListsCount, cancellationToken);

        var itemDescriptions = _mapper.Map<IEnumerable<ItemShortViewModel>>(items);

        var homeInfo = new HomeViewModel
        {
            LargestLists = lists,
            LastCreatedItems = itemDescriptions,
            Tags = tags
        };

        return homeInfo;
    }
}
