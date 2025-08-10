FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LoadBalancing.Yarp/LoadBalancing.Yarp.csproj", "./"]
RUN dotnet restore "./LoadBalancing.Yarp.csproj"
COPY LoadBalancing.Yarp/. ./LoadBalancing.Yarp/
WORKDIR "/src/LoadBalancing.Yarp"
RUN dotnet build "./LoadBalancing.Yarp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/LoadBalancing.Yarp"
RUN dotnet publish "./LoadBalancing.Yarp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoadBalancing.Yarp.dll"]
