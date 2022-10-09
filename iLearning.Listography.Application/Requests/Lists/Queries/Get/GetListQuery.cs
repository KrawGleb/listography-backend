using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.List.Queries.Get;

public class GetListQuery : IRequest<Response>
{
    public int Id { get; set; }
}
