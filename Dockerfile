#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./src/web/ECE.WebApp.MVC/ECE.WebApp.MVC.csproj", "ECE.WebApp.MVC"]
RUN dotnet restore "./ECE.WebApp.MVC/ECE.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/ECE.WebApp.MVC"
RUN dotnet build "./ECE.WebApp.MVC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECE.WebApp.MVC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_URLS="http://+:8080"
ENV ASPNETCORE_ENVIRONMENT="Development"

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECE.WebApp.MVC.dll"]