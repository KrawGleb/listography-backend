using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Search.Queries.Search;

public class SearchQuery : IRequest<Response>
{
    public string? SearchValue { get; set; }
}
