using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Home.Queries.Get;

public class GetHomeInfoQuery : IRequest<Response>
{
    public int ItemsCount { get; set; } = 5;
    public int TagsCount { get; set; } = 5;
    public int ListsCount { get; set; } = 5;
}
