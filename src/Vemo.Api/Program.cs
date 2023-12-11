using Vemo.Api;
using Vemo.Api.Middlewares;
using Vemo.Application;
using Vemo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
services.AddApiServices();
services.AddApplicationServices();
services.AddInfrastructureServices(configuration);

// App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseMiddleware<TokenExceptionHandlerMiddleware>();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
