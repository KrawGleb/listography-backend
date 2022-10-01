using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.List.Commands.AddItem;

public class AddItemCommand : IRequest
{
    public int ListId { get; set; }
    public string? Name { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
}
