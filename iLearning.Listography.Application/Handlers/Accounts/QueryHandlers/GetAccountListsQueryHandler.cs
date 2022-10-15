using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Accounts.QueryHandlers;

public class GetAccountListsQueryHandler : IRequestHandler<GetAccountListsQuery, Response>
{
    private readonly UserManager<Account> _userManager;

    public GetAccountListsQueryHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(GetAccountListsQuery request, CancellationToken cancellationToken)
    {
        var lists = await GetAccountListsAsync(request.Username);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = lists
        };
    }

    private async Task<IEnumerable<UserList>?> GetAccountListsAsync(string? username)
    {
        var account = await _userManager
            .Users
            .Include(u => u.Lists!)
                .ThenInclude(l => l.Topic)
            .FirstOrDefaultAsync(u => u.UserName == username)
        ?? throw new NotFoundException("Account not found");

        return account.Lists;
    }
}
