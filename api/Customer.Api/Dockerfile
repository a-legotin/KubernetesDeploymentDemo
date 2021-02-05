FROM  mcr.microsoft.com/dotnet/aspnet:5.0.2-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["api/Customer.Api/Customer.Api.csproj", "api/Customer.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Http/Common.Http.csproj", "common/Common.Http/"]
RUN dotnet restore "api/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/api/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8081
ENTRYPOINT ["dotnet", "Customer.Api.dll"]