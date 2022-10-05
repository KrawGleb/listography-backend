using iLearning.Listography.Application.Requests.Accounts.Queries.GetLists;
using iLearning.Listography.DataAccess.Models.Identity;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Accounts.QueryHandlers;

public class GetAccountListsQueryHandler : IRequestHandler<GetAccountListsQuery, IEnumerable<UserList>?>
{
    private readonly UserManager<Account> _userManager;

    public GetAccountListsQueryHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserList>?> Handle(GetAccountListsQuery request, CancellationToken cancellationToken)
    {
        var account = await _userManager
            .Users
            .Include(u => u.Lists)
            .FirstOrDefaultAsync(u => u.UserName == request.Username);

        if (account is null)
        {
            throw new InvalidOperationException();
        }

        return account.Lists;
    }
}
