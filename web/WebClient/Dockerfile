FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY web/WebClient/WebClient.csproj web/WebClient/
RUN dotnet restore web/WebClient/WebClient.csproj
COPY . .
WORKDIR /src/web/WebClient
RUN dotnet build WebClient.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebClient.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebClient.dll"]
