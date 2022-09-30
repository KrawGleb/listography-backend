using iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Accounts.QueryHandlers;

public class GetMeCommandHandler : IRequestHandler<GetMeQuery, Account?>
{
    private readonly UserManager<Account> _userManager;

    public GetMeCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Account?> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        return await _userManager
            .Users
            .Include(u => u.Lists)
            .ThenInclude(l => l.Tags)
            .FirstOrDefaultAsync(u => u.Id == request.Id);
    }
}
