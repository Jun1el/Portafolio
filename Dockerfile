FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Portafolio/Portafolio.csproj", "Portafolio/"]
RUN dotnet restore "Portafolio/Portafolio.csproj"
COPY . .
WORKDIR "/src/Portafolio"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Portafolio.dll"]
