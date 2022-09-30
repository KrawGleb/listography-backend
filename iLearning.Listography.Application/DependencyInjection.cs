using iLearning.Listography.Application.Models.Configurations;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace iLearning.Listography.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTConfiguration>((instance) =>
        {
            instance.Key = Environment.GetEnvironmentVariable("JWT.Key")!;
        });

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
