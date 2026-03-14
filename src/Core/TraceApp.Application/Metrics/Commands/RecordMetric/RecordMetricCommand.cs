using MediatR;

namespace TraceApp.Application.Metrics.Commands.RecordMetric;

public sealed record RecordMetricCommand(
    string Service,
    string Endpoint,
    string Method,
    int StatusCode,
    long DurationMs
) : IRequest;