namespace Vemo.Api;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}