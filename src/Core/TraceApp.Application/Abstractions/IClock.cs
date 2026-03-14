namespace TraceApp.Application.Abstractions;

public interface IClock
{
    DateTime UtcNow { get; }
}