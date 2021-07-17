# Jaeger OpenTelemetry .NET
Two simple ASP .NET Core microservices demonstrate OpenTelemetry .NET.

## Getting Started

The 2 services listen on the following ports:

- Service A: 5000 (5001 HTTPS)
- Service B: 6000 (6001 HTTPS)

### Visual Studio

...

### From the Command Line

```cmd
dotnet build
```

Run each service from its own terminal.

```cmd
cd "src\JaegerOpenTelemetryDotnetExample\JaegerOpenTelemetryDotnetExample.ServiceA\

dotnet run
```

and

```cmd
cd "src\JaegerOpenTelemetryDotnetExample\JaegerOpenTelemetryDotnetExample.ServiceB\

dotnet run
```
