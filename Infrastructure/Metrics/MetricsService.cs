using Core.Metrics;
using Infrastructure.Metrics.Interface;
using System.Diagnostics;

namespace Infrastructure.Metrics;

public class MetricsService : IMetricsService
{
    private int _totalRequests = 0;
    private int _totalErrors = 0;
    private Stopwatch _uptime = Stopwatch.StartNew();

    public void IncrementRequests() => Interlocked.Increment(ref _totalRequests);
    public void IncrementErrors() => Interlocked.Increment(ref _totalErrors);

    public MetricsDto GetCurrentMetrics()
    {
        return new MetricsDto
        {
            TotalRequests = _totalRequests,
            TotalErrors = _totalErrors,
            UptimeSeconds = (int)_uptime.Elapsed.TotalSeconds
        };
    }
}