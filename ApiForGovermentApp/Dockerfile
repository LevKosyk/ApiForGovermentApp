# Use Linux-based images (не nanoserver!)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiForGovermentApp/ApiForGovermentApp.csproj", "ApiForGovermentApp/"]
RUN dotnet restore "./ApiForGovermentApp/ApiForGovermentApp.csproj"
COPY . .
WORKDIR "/src/ApiForGovermentApp"
RUN dotnet build "./ApiForGovermentApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiForGovermentApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiForGovermentApp.dll"]
