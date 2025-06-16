using System.ComponentModel.DataAnnotations;
using Application.Services.Interfaces;
using Application.Transformer.Interface;
using Contracts.Errors;
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
    [ProducesResponseType(StatusCodes.Status200OK)]                      // Ok
    [ProducesResponseType(StatusCodes.Status400BadRequest)]             // Validation failure
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    // Unexpected error
    public async Task<IActionResult> ScanAsync([FromBody, Required] ScanRequestContract request)
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
            _logger.LogError("Invalid request: {Message}", ex.Message);
            return BadRequest(new ErrorMessage(ex.Message));
        }
        catch (NotSupportedException ex)
        {
            _logger.LogWarning("Unsupported ecosystem: {Message}", ex.Message);
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating contact.");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }
}