FROM  mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/Service.Orders/Service.Orders.csproj", "services/Service.Orders/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Bus.Abstractions/Common.Bus.Abstractions.csproj", "common/Common.Bus.Abstractions/"]
COPY ["common/Common.Bus.Events/Common.Bus.Events.csproj", "common/Common.Bus.Events/"]
RUN dotnet restore "services/Service.Orders/Service.Orders.csproj"
COPY . .
WORKDIR "/src/services/Service.Orders"
RUN dotnet build "Service.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.Orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Orders.dll"]