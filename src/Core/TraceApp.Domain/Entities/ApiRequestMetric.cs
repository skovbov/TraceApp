namespace TraceApp.Domain.Entities;

public class ApiRequestMetric
{
    public Guid Id { get; set; }

    public string Service { get; set; } = default!;
    public string Endpoint { get; set; } = default!;
    public string Method { get; set; } = default!;

    public int StatusCode { get; set; }

    public long DurationMs { get; set; }

    public DateTime Timestamp { get; set; }
}