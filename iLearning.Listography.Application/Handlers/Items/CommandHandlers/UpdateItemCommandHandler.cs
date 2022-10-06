using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Handlers.Items.CommandHandlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Response>
{
    private readonly IMapper _mapper;
    private readonly IItemsRepository _repository;

    public UpdateItemCommandHandler(
        IMapper mapper,
        IItemsRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var existingItem = await _repository.GetByIdAsync(request.Id, true);

        if (existingItem is null)
        {
            throw new NotFoundException("Item not exists");
        }

        var item = _mapper.Map<ListItem>(request);
        await _repository.UpdateAsync(existingItem, item);

        return new Response { Succeeded = true };
    }
}
