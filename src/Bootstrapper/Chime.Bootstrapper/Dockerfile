FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5069

ENV ASPNETCORE_URLS=http://+:5069

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Bootstrapper/Chime.Bootstrapper/Chime.Bootstrapper.csproj", "src/Bootstrapper/Chime.Bootstrapper/"]
RUN dotnet restore "src/Bootstrapper/Chime.Bootstrapper/Chime.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/src/Bootstrapper/Chime.Bootstrapper"
RUN dotnet build "Chime.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chime.Bootstrapper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chime.Bootstrapper.dll"]
