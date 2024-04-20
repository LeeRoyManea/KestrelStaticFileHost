FROM mcr.microsoft.com/dotnet/sdk:latest AS base
WORKDIR /app
EXPOSE 80

ENV TZ=Europe/Zurich
ENV DEBIAN_FRONTEND=noninteractive
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS="http://+:80"

FROM mcr.microsoft.com/dotnet/sdk:latest.0 AS build
WORKDIR /src
COPY . ./

RUN dotnet restore "KestrelStaticFileServer/KestrelStaticFileServer.csproj"
RUN dotnet build "KestrelStaticFileServer/KestrelStaticFileServer.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "KestrelStaticFileServer/KestrelStaticFileServer.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

HEALTHCHECK --interval=5s --timeout=3s CMD curl --silent --fail http://localhost:80/health || exit 1
            
ENTRYPOINT ["dotnet", "KestrelStaticFileServer.dll"]