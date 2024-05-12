FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY analytics-challenge/*.csproj ./analytics-challenge/
RUN dotnet restore analytics-challenge/analytics-challenge.csproj

COPY analytics-challenge-tests/*.csproj ./analytics-challenge-tests/
RUN dotnet restore analytics-challenge-tests/analytics-challenge-tests.csproj

COPY . .

WORKDIR /src/analytics-challenge/
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "analytics-challenge.dll"]
