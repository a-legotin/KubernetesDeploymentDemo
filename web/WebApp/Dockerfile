FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base

RUN apt-get -qq update -y \
    && apt-get -qq install curl gnupg -y \
    && curl --silent -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get -qq install nodejs -y

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

RUN apt-get -qq update -y \
    && apt-get -qq install curl gnupg -y \
    && curl --silent -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get -qq install nodejs -y

WORKDIR /src
COPY ["web/WebApp/WebApp.csproj", "web/WebApp/"]
RUN dotnet restore "web/WebApp/WebApp.csproj"
COPY . .
WORKDIR "/src/web/WebApp"
RUN dotnet build "WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]