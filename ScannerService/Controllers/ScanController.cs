using Application.Services.Interfaces;
using Application.Transformer.Interface;
using Contracts.Requests;
using Contracts.Responses;
using Core.Models.Scan;
using Microsoft.AspNetCore.Mvc;

namespace ScannerService.Controllers;

[ApiController]
[Route("api/v1")]
public class ScanController : ControllerBase
{

    private readonly IVulnerabilityScannerService _vulnerabilityScannerService;
    private readonly IVulnerabilityScannerTransformer _vulnerabilityScannerTransformer;
    private readonly ILogger<ScanController> _logger;

    public ScanController(IVulnerabilityScannerService vulnerabilityScannerService, IVulnerabilityScannerTransformer vulnerabilityScannerTransformer, ILogger<ScanController> logger)
    {
        _logger = logger;
        _vulnerabilityScannerService = vulnerabilityScannerService;
        _vulnerabilityScannerTransformer = vulnerabilityScannerTransformer;
    }

    [HttpPost("scan")]
    [ProducesResponseType(StatusCodes.Status201Created)]       // Created
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    // Validation failure
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Unexpected error
    public async Task<IActionResult> ScanAsync([FromBody] ScanRequestContract request)
    {
        try
        {
            ScanRequestEntity scanRequestEntity = _vulnerabilityScannerTransformer.TransformToScanRequestEntity(request);

            ScanResponseEntity result = await _vulnerabilityScannerService.ScanAsync(scanRequestEntity);

            ScanResponseContract responseContract = _vulnerabilityScannerTransformer.TransformToScanResponseContract(result);

            return Ok(responseContract);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning("Invalid request: {Message}", ex.Message);
            return BadRequest(new { error = ex.Message });
        }
        catch (NotSupportedException ex)
        {
            _logger.LogWarning("Unsupported ecosystem: {Message}", ex.Message);
            return BadRequest(new { error = ex.Message });
        }
    }
}