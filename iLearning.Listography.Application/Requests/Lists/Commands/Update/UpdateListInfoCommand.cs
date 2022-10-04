using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.Lists.Commands.Update;

public class UpdateListInfoCommand : IRequest<Response>
{
    public int Id { get; set; }
    public ListTopic? Topic { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }    
}
