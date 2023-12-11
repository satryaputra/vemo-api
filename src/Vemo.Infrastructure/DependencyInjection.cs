﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vemo.Application.Common.Interfaces;
using Vemo.Infrastructure.Persistence;
using Vemo.Infrastructure.Repositories.Users;

namespace Vemo.Infrastructure;

/// <summary>
/// DependencyInjection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// AddInfrastructureServices
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Persistence
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("LocalConnection"));
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
        // Users
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUserAuthInfoRepository, UserAuthInfoRepository>();
    }
}