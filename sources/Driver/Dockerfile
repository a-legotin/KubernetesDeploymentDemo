FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY sources/Driver/Driver.csproj sources/Driver/
RUN dotnet restore sources/Driver/Driver.csproj
COPY . .
WORKDIR /src/sources/Driver
RUN dotnet build Driver.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Driver.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Driver.dll"]
