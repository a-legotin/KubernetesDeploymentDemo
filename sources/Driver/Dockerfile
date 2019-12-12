FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["sources/Driver/Driver.csproj", "sources/Driver/"]
COPY ["common/Bus.Events/Bus.Events.csproj", "common/Bus.Events/"]
RUN dotnet restore "sources/Driver/Driver.csproj"
COPY . .
WORKDIR "/src/sources/Driver"
RUN dotnet build "Driver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Driver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Driver.dll"]