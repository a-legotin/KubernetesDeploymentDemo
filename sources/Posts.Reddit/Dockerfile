FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["sources/Posts.Reddit/Posts.Reddit.csproj", "sources/Posts.Reddit/"]
COPY ["common/Bus.RabbitMQ/Bus.RabbitMQ.csproj", "common/Bus.RabbitMQ/"]
COPY ["common/Bus.Abstractions/Bus.Abstractions.csproj", "common/Bus.Abstractions/"]
COPY ["common/Bus.Events/Bus.Events.csproj", "common/Bus.Events/"]
COPY ["common/Common.Models/Common.Models.csproj", "common/Common.Models/"]
COPY ["common/Http/Http.csproj", "common/Http/"]
RUN dotnet restore "sources/Posts.Reddit/Posts.Reddit.csproj"
COPY . .
WORKDIR "/src/sources/Posts.Reddit"
RUN dotnet build "Posts.Reddit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posts.Reddit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.Reddit.dll"]