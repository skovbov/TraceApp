using MediatR;
using TraceApp.Application.Metrics.Commands.RecordMetric;

namespace TraceApp.Api.Endpoints.Metrics;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapMetricsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/metrics", async (
                RecordMetricRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new RecordMetricCommand(
                    request.Service,
                    request.Endpoint,
                    request.Method,
                    request.StatusCode,
                    request.DurationMs,
                    DateTime.UtcNow);

                await sender.Send(command, cancellationToken);

                return Results.Accepted();
            })
            .WithName("RecordMetric")
            .WithTags("Metrics");

        return app;
    }
}