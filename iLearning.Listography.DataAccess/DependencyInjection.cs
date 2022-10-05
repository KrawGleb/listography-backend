using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Implementations.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLearning.Listography.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Secure connection string.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Default"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

        services.AddIdentity<Account, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;

            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IListsRepository, ListsRepository>();
        services.AddScoped<ITagsRepository, TagsRepository>();
        services.AddScoped<ICustomFieldsRepository, CustomFieldsRepository>();
        services.AddScoped<ITopicsRepository, TopicsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();

        return services;
    }
}
