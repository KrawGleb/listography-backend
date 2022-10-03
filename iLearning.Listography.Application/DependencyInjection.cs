using iLearning.Listography.Application.Models.Configurations;
using iLearning.Listography.Application.Services.Implementatinos;
using iLearning.Listography.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace iLearning.Listography.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTConfiguration>(configuration.GetSection("JWT"));

        services.AddScoped<IUserPermissionsService, UserPermissionsService>();

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
