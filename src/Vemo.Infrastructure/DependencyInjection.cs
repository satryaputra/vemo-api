using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vemo.Application.Common.Interfaces;
using Vemo.Infrastructure.Persistence;
using Vemo.Infrastructure.Repositories.User;

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
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
}