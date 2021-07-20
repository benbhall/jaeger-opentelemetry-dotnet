FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /build
COPY src/JaegerOpenTelemetryDotnetExample/JaegerOpenTelemetryDotnetExample.ServiceA .
RUN dotnet restore  

RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JaegerOpenTelemetryDotnetExample.ServiceA.dll"]