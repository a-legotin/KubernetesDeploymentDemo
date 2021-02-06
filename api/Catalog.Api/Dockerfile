FROM  mcr.microsoft.com/dotnet/aspnet:5.0.2-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["api/Catalog.Api/Catalog.Api.csproj", "api/Catalog.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Bus.Abstractions/Common.Bus.Abstractions.csproj", "common/Common.Bus.Abstractions/"]
COPY ["common/Common.Bus.Events/Common.Bus.Events.csproj", "common/Common.Bus.Events/"]
COPY ["common/Common.Bus.RabbitMQ/Common.Bus.RabbitMQ.csproj", "common/Common.Bus.RabbitMQ/"]

RUN dotnet restore "api/Catalog.Api/Catalog.Api.csproj"
COPY . .
WORKDIR "/src/api/Catalog.Api"
RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8082
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]