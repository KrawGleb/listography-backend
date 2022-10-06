using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Common.Interfaces;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Delete;

public class DeleteItemCommand : IRequest<Response>, IProtectedItemRequest
{
    public int Id { get; set; }
}
