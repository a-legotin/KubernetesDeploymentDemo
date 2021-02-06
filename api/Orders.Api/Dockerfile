FROM  mcr.microsoft.com/dotnet/aspnet:5.0.2-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["api/Orders.Api/Orders.Api.csproj", "api/Orders.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
RUN dotnet restore "api/Orders.Api/Orders.Api.csproj"
COPY . .
WORKDIR "/src/api/Orders.Api"
RUN dotnet build "Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8083
ENTRYPOINT ["dotnet", "Orders.Api.dll"]