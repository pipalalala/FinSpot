FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5100
EXPOSE 5101

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FinSpotAPI.Web/FinSpotAPI.Web.csproj", "FinSpotAPI.Web/"]
COPY ["FinSpotAPI.Application/FinSpotAPI.Application.csproj", "FinSpotAPI.Application/"]
COPY ["FinSpotAPI.Domain/FinSpotAPI.Domain.csproj", "FinSpotAPI.Domain/"]
COPY ["FinSpotAPI.Domain.Migrations/FinSpotAPI.Domain.Migrations.csproj", "FinSpotAPI.Domain.Migrations/"]
COPY ["FinSpotAPI.Common/FinSpotAPI.Common.csproj", "FinSpotAPI.Common/"]
COPY ["FinSpotAPI.Infrastructure/FinSpotAPI.Infrastructure.csproj", "FinSpotAPI.Infrastructure/"]
RUN dotnet restore "./FinSpotAPI.Web/FinSpotAPI.Web.csproj"
COPY . .
WORKDIR "/src/FinSpotAPI.Web"
RUN dotnet build "./FinSpotAPI.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FinSpotAPI.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinSpotAPI.Web.dll"]