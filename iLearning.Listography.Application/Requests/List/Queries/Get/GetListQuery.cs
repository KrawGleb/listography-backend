using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.List.Queries.Get;

public class GetListQuery : IRequest<UserList?>
{
    public int Id { get; set; }
}
