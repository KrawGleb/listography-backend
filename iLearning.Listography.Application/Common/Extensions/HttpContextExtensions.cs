using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Application.Common.Extensions;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext context)
    {
        return context is null
            ? string.Empty
            : context.User.Claims.SingleOrDefault(x => x.Type == "id")?.Value ?? string.Empty;
    }
}
