# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish "src/Vemo.Api/Vemo.Api.csproj" -c Release -o /app

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Vemo.Api.dll"]
