FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["api/Posts.API/Posts.API.csproj", "api/Posts.API/"]
RUN dotnet restore "api/Posts.API/Posts.API.csproj"
COPY . .
WORKDIR "/src/api/Posts.API"
RUN dotnet build "Posts.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posts.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.API.dll"]