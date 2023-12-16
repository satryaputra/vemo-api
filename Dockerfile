# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore --disable-parallel
RUN dotnet publish "src/Vemo.Api/Vemo.Api.csproj" --configuration Release --output /app --framework net6.0 --no-restore

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app .

ENV ConnectionStrings__DefaultConnection="Host=postgres;Port=5432;Database=vemodev;Username=postgres;Password=postgres;"
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "Vemo.Api.dll"]
