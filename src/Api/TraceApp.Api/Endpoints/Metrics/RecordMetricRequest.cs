namespace TraceApp.Api.Endpoints.Metrics;

public sealed record RecordMetricRequest(
    string Service,
    string Endpoint,
    string Method,
    int StatusCode,
    long DurationMs
);