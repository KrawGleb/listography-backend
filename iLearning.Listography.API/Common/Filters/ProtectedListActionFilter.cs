using iLearning.Listography.Application.Requests.Common.Interfaces;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iLearning.Listography.API.Filters;

public class ProtectedListActionFilter : IAsyncActionFilter
{
    private readonly IUserPermissionsService _userPermissionsService;

    public ProtectedListActionFilter(IUserPermissionsService userPermissionsService)
    {
        _userPermissionsService = userPermissionsService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isRequestValid = false;

        var request = context.ActionArguments.Values.FirstOrDefault(v => v is IProtectedListRequest) as IProtectedListRequest;
        if (request is not null)
        {
            var listId = request.ListId!;
            var userId = context.HttpContext.GetUserId();

            isRequestValid = await _userPermissionsService.AllowEditListAsync(userId, listId);
        }

        if (isRequestValid)
        {
            await next();
        }

        context.Result = new ForbidResult();
    }
}
