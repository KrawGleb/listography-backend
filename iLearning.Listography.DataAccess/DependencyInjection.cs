﻿using iLearning.Listography.DataAccess.Implementations;
using iLearning.Listography.DataAccess.Implementations.Repositories;
using iLearning.Listography.DataAccess.Implementations.Services.Elastic;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Interfaces.Services.Elastic;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.Constants;
using iLearning.Listography.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

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

        services.AddElasticClient(configuration);

        services.AddScoped<IListsRepository, ListsRepository>();
        services.AddScoped<ITagsRepository, TagsRepository>();
        services.AddScoped<ICustomFieldsRepository, CustomFieldsRepository>();
        services.AddScoped<ITopicsRepository, TopicsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();

        return services;
    }

    private static IServiceCollection AddElasticClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IElasticClient>(factory =>
        {
            var settings = new ConnectionSettings(new Uri("https://4qkagpt4m:slsrx87cz1@jasmine-749629487.eu-west-1.bonsaisearch.net:443"))
                .DefaultMappingFor<SearchItem>(i => i.IndexName(ElasticConstants.ItemIndexName))
                .EnableHttpCompression()
                .ConnectionLimit(-1);

            var client = new ElasticClient(settings);

            client.Indices.Create(
                ElasticConstants.ItemIndexName,
                index => index.Map<SearchItem>(x => x.AutoMap()));

            return client;
        });

        services.AddScoped<IElasticService, ElasticService>();

        return services;
    }
}
