FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# EXPOSE 5198

# ENV ASPNETCORE_URLS=http://+:5198

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Dotnet.API/Dotnet.API.csproj", "Dotnet.API/"]
RUN dotnet restore "Dotnet.API/Dotnet.API.csproj"
COPY . .
WORKDIR "/src/Dotnet.API"
RUN dotnet build "Dotnet.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Dotnet.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.API.dll"]
