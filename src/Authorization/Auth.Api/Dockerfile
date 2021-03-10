#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Authorization/Auth.Api/Auth.Api.csproj", "src/Authorization/Auth.Api/"]
COPY ["src/Authorization/Auth.Infrastructure/Auth.Infrastructure.csproj", "src/Authorization/Auth.Infrastructure/"]
COPY ["src/Authorization/Auth.Core/Auth.Core.csproj", "src/Authorization/Auth.Core/"]
COPY ["src/Authorization/ClassLibrary1/Auth.Application.csproj", "src/Authorization/ClassLibrary1/"]
RUN dotnet restore "src/Authorization/Auth.Api/Auth.Api.csproj"
COPY . .
WORKDIR "/src/src/Authorization/Auth.Api"
RUN dotnet build "Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Api.dll"]
