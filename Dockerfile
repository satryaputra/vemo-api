# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore --disable-parallel
RUN dotnet publish "src/Vemo.Api/Vemo.Api.csproj" --configuration Release --output /app --framework net6.0 --no-restore

# Update Database
RUN dotnet ef database update --project src/Vemo.Infrastructure --startup-project src/Vemo.Api --context Vemo.Infrastructure.Persistence.ApplicationDbContext

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app .

EXPOSE 80

ENTRYPOINT ["dotnet", "Vemo.Api.dll"]
