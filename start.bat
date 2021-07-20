docker build -t aspcore-service-a -f src\JaegerOpenTelemetryDotnetExample\JaegerOpenTelemetryDotnetExample.ServiceA\Dockerfile .
docker build -t aspcore-service-b -f src\JaegerOpenTelemetryDotnetExample\JaegerOpenTelemetryDotnetExample.ServiceB\Dockerfile .
docker-compose up