using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.List;
using iLearning.Listography.Application.Requests.Common.Interfaces;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Add;

public class AddItemCommand : IRequest<Response>, IProtectedListRequest
{
    public int ListId { get; set; }
    public string? Name { get; set; }
    public ICollection<TagViewModel>? Tags { get; set; }
    public ICollection<CustomFieldViewModel>? CustomFields { get; set; }
}
