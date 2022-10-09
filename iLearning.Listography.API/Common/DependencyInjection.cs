using iLearning.Listography.API.Filters;

namespace iLearning.Listography.API.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddFilters(this IServiceCollection services)
    {
        services.AddScoped<ProtectedListActionFilter>();
        services.AddScoped<ProtectedItemActionFilter>();

        return services;
    }
}
