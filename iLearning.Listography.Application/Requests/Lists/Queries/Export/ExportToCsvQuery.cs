using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Lists.Queries.Export;

public class ExportToCsvQuery : IRequest<CommonResponse>
{
    public int ListId { get; set; }
}
