FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

#Install debugger
RUN apt-get update
RUN apt-get install curl -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

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
