dotnet ef migrations add InitialDb --project src/Vemo.Infrastructure --startup-project src/Vemo.Api --context Vemo.Infrastructure.Persistence.ApplicationDbContext --configuration Debug --output-dir Persistence/Migrations

dotnet ef database update --project src/Vemo.Infrastructure --startup-project src/Vemo.Api --context Vemo.Infrastructure.Persistence.ApplicationDbContext --configuration Debug