FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["service/Posts.Service/Posts.Service.csproj", "service/Posts.Service/"]
COPY ["common/Bus.RabbitMQ/Bus.RabbitMQ.csproj", "common/Bus.RabbitMQ/"]
COPY ["common/Bus.Abstractions/Bus.Abstractions.csproj", "common/Bus.Abstractions/"]
COPY ["common/Bus.Events/Bus.Events.csproj", "common/Bus.Events/"]
COPY ["common/Common.Models/Common.Models.csproj", "common/Common.Models/"]
COPY ["common/Http/Http.csproj", "common/Http/"]
RUN dotnet restore "service/Posts.Service/Posts.Service.csproj"
COPY . .
WORKDIR "/src/service/Posts.Service"
RUN dotnet build "Posts.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posts.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.Service.dll"]