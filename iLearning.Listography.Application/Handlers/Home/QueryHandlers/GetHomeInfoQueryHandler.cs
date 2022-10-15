using AutoMapper;
using iLearning.Listography.Application.Models.Home;
using iLearning.Listography.Application.Models.Responses;
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
        var homeInfo = await GetHomeInfoAsync(request);

        return new CommonResponse
        {
            Succeeded = true,
            Body = homeInfo
        };
    }

    private async Task<HomeInfo> GetHomeInfoAsync(GetHomeInfoQuery request)
    {
        var items = await _itemsRepository.GetLastCreated(request.ItemsCount);
        var tags = await _tagsRepository.GetRandomAsync(request.TagsCount);
        var lists = await _listsRepository.GetLargestAsync(request.ListsCount);

        var itemDescriptions = _mapper.Map<IEnumerable<ItemShortDescription>>(items);

        var homeInfo = new HomeInfo
        {
            LargestLists = lists,
            LastCreatedItems = itemDescriptions,
            Tags = tags
        };

        return homeInfo;
    }
}
