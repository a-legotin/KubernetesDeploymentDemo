FROM  mcr.microsoft.com/dotnet/aspnet:5.0.2-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["api/CustomerService.Api/CustomerService.Api.csproj", "api/CustomerService.Api/"]
COPY ["common/Common.Core/Common.Core.csproj", "common/Common.Core/"]
COPY ["common/Common.Http/Common.Http.csproj", "common/Common.Http/"]
RUN dotnet restore "api/CustomerService.Api/CustomerService.Api.csproj"
COPY . .
WORKDIR "/src/api/CustomerService.Api"
RUN dotnet build "CustomerService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "CustomerService.Api.dll"]