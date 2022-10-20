using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Common.Identity;
using iLearning.Listography.Application.Requests.Admin.Queries.GetUserInfo;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.Listography.Application.Handlers.Admin.QueryHandlers;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetUserInfoQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username) 
            ?? throw new NotFoundException($"There isn't any user with ${request.Username} username");

        var info = new UserViewModel
        {
            Username = request.Username,
            Blocked = user.State == UserState.Blocked,
            IsAdmin = await _userManager.IsInRoleAsync(user, RolesEnum.Admin)
        };

        return new CommonResponse
        {
            Succeeded = true,
            Body = info
        };
    }
}
