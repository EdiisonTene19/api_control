# Imagen base de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api_control.csproj", "./"]
RUN dotnet restore "api_control.csproj"
COPY . .
RUN dotnet build "api_control.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_control.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_control.dll"]
