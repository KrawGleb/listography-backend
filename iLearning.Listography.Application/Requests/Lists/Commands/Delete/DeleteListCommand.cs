using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Common.Interfaces;
using MediatR;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Delete;

public class DeleteListCommand : IRequest<Response>, IProtectedListRequest
{
    public int ListId { get; set; }
}
