using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Delete;

public class DeleteListCommand : IRequest<Response>
{
    public int Id { get; set; }
}
