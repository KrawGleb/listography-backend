using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.List.Commands.Create;

public class CreateListCommand : IRequest
{
    public string? UserId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ListTopic? Topic { get; set; }
    public ListItemTemplate? ItemTemplate { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
}
