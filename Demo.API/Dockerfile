FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 3000
ENV ASPNETCORE_URLS=http://+:3000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Demo.API/Demo.API.csproj", "Demo.API/"]
COPY ["Demo.Application/Demo.Application.csproj", "Demo.Application/"]
COPY ["Demo.Domain/Demo.Domain.csproj", "Demo.Domain/"]
COPY ["Demo.Infrastructure/Demo.Infrastructure.csproj", "Demo.Infrastructure/"]

RUN dotnet restore "./Demo.API/Demo.API.csproj"
COPY . .
WORKDIR "/src/Demo.API"
RUN dotnet publish "./Demo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Demo.API.dll"]