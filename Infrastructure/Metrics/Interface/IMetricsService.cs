using Core.Metrics;

namespace Infrastructure.Metrics.Interface;

public interface IMetricsService
{
    void IncrementRequests();
    void IncrementErrors();
    MetricsDto GetCurrentMetrics();
}