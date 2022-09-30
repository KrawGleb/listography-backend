﻿using Microsoft.AspNetCore.Http;

namespace iLearning.Listography.Infrastructure.Extensions;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext context)
    {
        return context is null
            ? string.Empty
            : context
                .User
                .Claims
                .Single(x => x.Type == "id")
                .Value;
    }
}