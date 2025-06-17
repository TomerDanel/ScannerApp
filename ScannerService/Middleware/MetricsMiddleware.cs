using Infrastructure.Metrics.Interface;

namespace ScannerService.Middleware;

public class MetricsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMetricsService _metricsService;

    public MetricsMiddleware(RequestDelegate next, IMetricsService metricsService)
    {
        _next = next;
        _metricsService = metricsService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _metricsService.IncrementRequests();

        try
        {
            await _next(context);
        }
        catch
        {
            _metricsService.IncrementErrors();
            throw;
        }
    }
}