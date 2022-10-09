using AutoMapper;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Response>
{
    private readonly IListsRepository _listsRepository;
    private readonly IMapper _mapper;

    public AddItemCommandHandler(
        IListsRepository listsRepository,
        IMapper mapper)
    {
        _listsRepository = listsRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<ListItem>(request);
        await _listsRepository.AddItemToListAsync(request.ListId, item);

        return new CommonResponse
        {
            Succeeded = true,
            Body = item
        };
    }
}
