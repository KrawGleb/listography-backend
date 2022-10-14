using iLearning.Listography.Application.Models.Common;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Admin.Queries.GetUserInfo;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLearning.Listography.Application.Handlers.Admin.QueryHandlers;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, Response>
{
    private readonly UserManager<Account> _userManager;

    public GetUserInfoQueryHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        var info = new AccountModel
        {
            Username = request.Username,
            Blocked = user.State == AccountState.Blocked,
            IsAdmin = await _userManager.IsInRoleAsync(user, RolesEnum.Admin)
        };

        return new CommonResponse
        {
            Succeeded = true,
            Body = info
        };
    }
}
