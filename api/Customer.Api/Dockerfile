﻿FROM  mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.21 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["api/Customer.Api/Customer.Api.csproj", "api/Customer.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Bus.Abstractions/Common.Bus.Abstractions.csproj", "common/Common.Bus.Abstractions/"]
COPY ["common/Common.Bus.Events/Common.Bus.Events.csproj", "common/Common.Bus.Events/"]
RUN dotnet restore "api/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/api/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Customer.Api.dll"]