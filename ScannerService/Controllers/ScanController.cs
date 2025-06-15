using Application.Services.Interfaces;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ScannerService.Controllers;

[ApiController]
[Route("api/v1")]
public class ScanController : ControllerBase
{

    private readonly IVulnerabilityScannerService _scanner;
    private readonly ILogger<ScanController> _logger;

    public ScanController(IVulnerabilityScannerService scanner, ILogger<ScanController> logger)
    {
        _scanner = scanner;
        _logger = logger;
    }

    [HttpPost("scan")]
    [ProducesResponseType(StatusCodes.Status201Created)]       // Created
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    // Validation failure
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Unexpected error
    public async Task<IActionResult> ScanAsync([FromBody] ScanRequestContract request)
    {
        try
        {
            var result = await _scanner.ScanAsync(request);

            return Ok(result);
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