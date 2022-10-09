using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Create;

public class CreateListCommand : IRequest<Response>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ListTopic? Topic { get; set; }
    public ListItemTemplate? ItemTemplate { get; set; }
}
