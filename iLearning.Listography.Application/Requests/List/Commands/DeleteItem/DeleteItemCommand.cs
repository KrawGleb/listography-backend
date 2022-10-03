using MediatR;

namespace iLearning.Listography.Application.Requests.List.Commands.DeleteItem;

public class DeleteItemCommand : IRequest
{
    public int Id { get; set; }
}
