using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Queries.Get;

public class GetItemQuery : IRequest<Response>
{
    public int Id { get; set; }
}
