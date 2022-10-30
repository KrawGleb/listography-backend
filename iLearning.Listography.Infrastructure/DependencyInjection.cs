using iLearning.Listography.Infrastructure.Filters;
using iLearning.Listography.Infrastructure.Services.Implementations;
using iLearning.Listography.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.Listography.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserPermissionsService, UserPermissionsService>();

        services.AddScoped<ProtectedItemActionFilter>();
        services.AddScoped<ProtectedListActionFilter>();

        return services;
    }
}
