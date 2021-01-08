FROM mcr.microsoft.com/dotnet/core/runtime:3.1.10-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["sources/Posts.Wiki/Posts.Wiki.csproj", "sources/Posts.Wiki/"]
COPY ["common/Bus.RabbitMQ/Bus.RabbitMQ.csproj", "common/Bus.RabbitMQ/"]
COPY ["common/Bus.Abstractions/Bus.Abstractions.csproj", "common/Bus.Abstractions/"]
COPY ["common/Bus.Events/Bus.Events.csproj", "common/Bus.Events/"]
COPY ["common/Common.Models/Common.Models.csproj", "common/Common.Models/"]
COPY ["common/Http/Http.csproj", "common/Http/"]
RUN dotnet restore "sources/Posts.Wiki/Posts.Wiki.csproj"
COPY . .
WORKDIR "/src/sources/Posts.Wiki"
RUN dotnet build "Posts.Wiki.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posts.Wiki.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.Wiki.dll"]