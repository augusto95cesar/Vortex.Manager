#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Vortex.Manager.WebApp/Vortex.Manager.WebApp.csproj", "Vortex.Manager.WebApp/"]
RUN dotnet restore "Vortex.Manager.WebApp/Vortex.Manager.WebApp.csproj"
COPY . .
WORKDIR "/src/Vortex.Manager.WebApp"
RUN dotnet build "Vortex.Manager.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vortex.Manager.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vortex.Manager.WebApp.dll"]