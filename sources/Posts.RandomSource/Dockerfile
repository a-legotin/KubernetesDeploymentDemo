FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["sources/Posts.RandomSource/Posts.RandomSource.csproj", "sources/Posts.RandomSource/"]
COPY ["common/Bus.Abstractions/Bus.Abstractions.csproj", "common/Bus.Abstractions/"]
COPY ["common/Bus.Events/Bus.Events.csproj", "common/Bus.Events/"]
COPY ["common/Bus.RabbitMQ/Bus.RabbitMQ.csproj", "common/Bus.RabbitMQ/"]

RUN dotnet restore "sources/Posts.RandomSource/Posts.RandomSource.csproj"
COPY . .
WORKDIR "/src/sources/Posts.RandomSource"
RUN dotnet build "Posts.RandomSource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posts.RandomSource.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.RandomSource.dll"]