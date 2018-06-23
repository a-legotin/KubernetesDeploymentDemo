FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY api/Documents.Api/Documents.Api.csproj api/Documents.Api/
RUN dotnet restore api/Documents.Api/Documents.Api.csproj
COPY . .
WORKDIR /src/api/Documents.Api
RUN dotnet build Documents.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Documents.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

#Install debugger
RUN apt-get update
RUN apt-get install curl -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENTRYPOINT ["dotnet", "Documents.Api.dll"]
