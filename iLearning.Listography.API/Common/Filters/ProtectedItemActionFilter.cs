using iLearning.Listography.Application.Requests.Common.Interfaces;
using iLearning.Listography.Application.Services.Interfaces;
using iLearning.Listography.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iLearning.Listography.API.Filters;

public class ProtectedItemActionFilter : IAsyncActionFilter
{
    private readonly IUserPermissionsService _userPermissionsService;

    public ProtectedItemActionFilter(IUserPermissionsService userPermissionsService)
    {
        _userPermissionsService = userPermissionsService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isRequestValid = false;

        var request = context.ActionArguments.Values.FirstOrDefault(v => v is IProtectedItemRequest) as IProtectedItemRequest;
        if (request is not null)
        {
            var itemId = request.Id!;
            var userId = context.HttpContext.GetUserId();

            isRequestValid = await _userPermissionsService.AllowEditItemAsync(userId, itemId);
        }

        if (isRequestValid)
        {
            await next();
        }

        context.Result = new ForbidResult();
    }
}
