using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Accounts.QueryHandlers;

public class GetMeCommandHandler : IRequestHandler<GetMeQuery, Response>
{
    private readonly UserManager<Account> _userManager;

    public GetMeCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var account = await GetAccountAsync(request.Id!);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = account
        };

    }

    private async Task<Account> GetAccountAsync(string id)
    {
        var account = await _userManager
            .Users
            .Include(u => u.Lists!)
                .ThenInclude(l => l.Topic)
            .FirstOrDefaultAsync(u => u.Id == id)
       ?? throw new NotFoundException("Account not found");

        return account;
    }
}
