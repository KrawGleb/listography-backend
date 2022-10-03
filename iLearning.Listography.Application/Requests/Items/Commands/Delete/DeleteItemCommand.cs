using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Delete;

public class DeleteItemCommand : IRequest
{
    public int Id { get; set; }
}
