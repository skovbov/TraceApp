using TraceApp.Application.Abstractions;

namespace TraceApp.Infrastructure.Time;

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}