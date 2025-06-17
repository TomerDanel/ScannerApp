using Infrastructure.Metrics.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ScannerService.Controllers;

[ApiController]
[Route("api/v1/metrics")]
public class MetricsController : ControllerBase
{
    private readonly IMetricsService _metricsService;

    public MetricsController(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    [HttpGet]
    public IActionResult GetMetrics()
    {
        var metrics = _metricsService.GetCurrentMetrics();
        return Ok(metrics);
    }
}