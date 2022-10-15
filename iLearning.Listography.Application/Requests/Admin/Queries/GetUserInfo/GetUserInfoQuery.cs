using iLearning.Listography.Application.Models.Responses;
using MediatR;

namespace iLearning.Listography.Application.Requests.Admin.Queries.GetUserInfo;

public class GetUserInfoQuery : IRequest<Response>
{
    public string? Username { get; set; }
}
