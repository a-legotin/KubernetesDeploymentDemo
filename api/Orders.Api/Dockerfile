﻿FROM  mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api/Orders.Api/Orders.Api.csproj", "api/Orders.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Bus.Abstractions/Common.Bus.Abstractions.csproj", "common/Common.Bus.Abstractions/"]
COPY ["common/Common.Bus.Events/Common.Bus.Events.csproj", "common/Common.Bus.Events/"]
COPY ["common/Common.Bus.RabbitMQ/Common.Bus.RabbitMQ.csproj", "common/Common.Bus.RabbitMQ/"]
RUN dotnet restore "api/Orders.Api/Orders.Api.csproj"
COPY . .
WORKDIR "/src/api/Orders.Api"
RUN dotnet build "Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Orders.Api.dll"]