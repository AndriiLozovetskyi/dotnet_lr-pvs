FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["dotnet-site-project/dotnet-site-project.csproj", "dotnet-site-project/"]
RUN dotnet restore "dotnet-site-project/dotnet-site-project.csproj"
COPY . .
WORKDIR "/src/dotnet-site-project"
RUN dotnet build "dotnet-site-project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-site-project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-site-project.dll"]
