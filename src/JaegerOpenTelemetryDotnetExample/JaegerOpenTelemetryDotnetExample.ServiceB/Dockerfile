FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

EXPOSE 6001
ENV ASPNETCORE_URLS=http://+:6001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /build
COPY src/JaegerOpenTelemetryDotnetExample/JaegerOpenTelemetryDotnetExample.ServiceB .
RUN dotnet restore  

RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JaegerOpenTelemetryDotnetExample.ServiceB.dll"]