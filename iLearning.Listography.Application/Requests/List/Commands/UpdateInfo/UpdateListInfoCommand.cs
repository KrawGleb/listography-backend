using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.List.Commands.UpdateInfo;

public class UpdateListInfoCommand : IRequest<Response>
{
    public int ListId { get; set; }
    public ListTopic? Topic { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }    
    public IEnumerable<ListTag>? Tags { get; set; }
}
