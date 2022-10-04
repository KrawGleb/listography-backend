using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Delete;

public class DeleteItemCommand : IRequest<Response>
{
    public int Id { get; set; }
}
