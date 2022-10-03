using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Add;

public class AddItemCommand : IRequest<Response>
{
    public int ListId { get; set; }
    public string? Name { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
}
