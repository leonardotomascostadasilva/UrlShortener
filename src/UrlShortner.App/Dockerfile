FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/UrlShortner.App/UrlShortner.App.csproj", "src/UrlShortner.App/"]
RUN dotnet restore "src/UrlShortner.App/UrlShortner.App.csproj"
COPY . .
WORKDIR "/src/src/UrlShortner.App"
RUN dotnet build "UrlShortner.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrlShortner.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrlShortner.App.dll"]