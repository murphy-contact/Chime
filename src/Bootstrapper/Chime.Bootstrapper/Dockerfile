FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Bootstrapper/Chime.Bootstrapper/Chime.Bootstrapper.csproj", "src/Bootstrapper/Chime.Bootstrapper/"]
RUN dotnet restore "src/Bootstrapper/Chime.Bootstrapper/Chime.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/src/Bootstrapper/Chime.Bootstrapper"
RUN dotnet build "Chime.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chime.Bootstrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chime.Bootstrapper.dll"]
