﻿using Microsoft.Extensions.DependencyInjection;
using Vemo.Application.Common.Behaviors;

namespace Vemo.Application;

/// <summary>
/// Dependency Injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// AddApplicationServices
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        
        services.AddAutoMapper(assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}