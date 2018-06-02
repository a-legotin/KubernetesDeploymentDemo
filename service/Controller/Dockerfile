FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY service/Controller/Controller.csproj service/Controller/
RUN dotnet restore service/Controller/Controller.csproj
COPY . .
WORKDIR /src/service/Controller
RUN dotnet build Controller.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Controller.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Controller.dll"]
