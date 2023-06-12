FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BarVisionAPI.csproj", "./"]
RUN dotnet restore "./BarVisionAPI.csproj"
COPY . .
RUN dotnet build "BarVisionAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BarVisionAPI.csproj" -c Release -o /app

VOLUME /app/logs

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BarVisionAPI.dll"]