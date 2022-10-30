using iLearning.Listography.Application.Models.Configurations;
using iLearning.Listography.Application.Services.Implementatinos;
using iLearning.Listography.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using iLearning.Listography.Application.Common.Behaviours;

namespace iLearning.Listography.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);
        
        services.Configure<JwtConfiguration>((instance) =>
        {
            instance.Key = Environment.GetEnvironmentVariable("JWT.Key")!;
        });

        services.AddScoped<IAuthService, AuthService>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
