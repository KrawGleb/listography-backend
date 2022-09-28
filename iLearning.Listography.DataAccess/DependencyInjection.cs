using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.Listography.DataAccess;

public static class DependencyInjection
{
    // TODO: Rename or split it.
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Secure connection string.
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddIdentity<Account, IdentityRole>(options => { })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
