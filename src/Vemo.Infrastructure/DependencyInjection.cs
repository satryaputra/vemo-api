using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vemo.Application.Common.Interfaces;
using Vemo.Infrastructure.Persistence;
using Vemo.Infrastructure.Repositories.Users;
using Vemo.Infrastructure.Repositories.Vehicles;
using Vemo.Infrastructure.Services;
using IEmailService = Vemo.Application.Common.Interfaces.IEmailService;

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
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
        // Users
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserAuthInfoRepository, UserAuthInfoRepository>();
        
        // Vehicles
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehiclePartRepository, VehiclePartRepository>();
        services.AddScoped<IVehiclePartConditionRepository, VehiclePartConditionRepository>();
        
        // Services
        services.AddScoped<IEmailService, EmailService>();
    }
}