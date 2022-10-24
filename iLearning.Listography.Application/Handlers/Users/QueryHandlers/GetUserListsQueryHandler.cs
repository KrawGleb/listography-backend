using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Users.Queries.GetLists;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Users.QueryHandlers;

public class GetUserListsQueryHandler : IRequestHandler<GetUserListsQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetUserListsQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(GetUserListsQuery request, CancellationToken cancellationToken)
    {
        var lists = await GetUserListsAsync(request.Username, cancellationToken);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = lists
        };
    }

    private async Task<IEnumerable<UserList>?> GetUserListsAsync(string? username, CancellationToken cancellationToken)
    {
        var user = await _userManager
            .Users
            .Include(u => u.Lists!)
                .ThenInclude(l => l.Topic)
            .FirstOrDefaultAsync(u => u.UserName == username, cancellationToken)
        ?? throw new NotFoundException("User not found");

        return user.Lists;
    }
}
