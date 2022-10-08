using iLearning.Listography.Application.Models;
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

    public GetHomeInfoQueryHandler(
        IItemsRepository itemsRepository,
        ITagsRepository tagsRepository,
        IListsRepository listsRepository)
    {
        _itemsRepository = itemsRepository;
        _tagsRepository = tagsRepository;
        _listsRepository = listsRepository;
    }

    public async Task<Response> Handle(GetHomeInfoQuery request, CancellationToken cancellationToken)
    {
        // TODO: Review it.
        var fiveLastCreated = await _itemsRepository.GetLastCreated(5);
        var tenRandomTags = await _tagsRepository.GetRandomAsync(10);
        var threeLargesLists = await _listsRepository.GetLargestAsync(3);

        // TODO: Use automapper.
        var itemDescriptions = fiveLastCreated.Select(i =>
        {
            return new ItemDescription
            {
                Id = i.Id,
                Name = i.Name,
                ListName = i.UserList?.Title,
                Author = i.UserList?.Account?.UserName
            };
        });

        var homeInfo = new HomeInfo
        {
            LargestLists = threeLargesLists,
            LastCreatedItems = itemDescriptions,
            Tags = tenRandomTags
        };

        return new CommonResponse
        {
            Succeeded = true,
            Body = homeInfo
        };
    }
}
