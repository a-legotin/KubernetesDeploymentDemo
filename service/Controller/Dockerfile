FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["service/Controller/Controller.csproj", "service/Controller/"]
RUN dotnet restore "service/Controller/Controller.csproj"
COPY . .
WORKDIR "/src/service/Controller"
RUN dotnet build "Controller.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Controller.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Controller.dll"]