using Api.Document.Models;
using Api.Document.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Document.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PdfController(ILogger<PdfController> _logger, IPdfService _pdfService) : ControllerBase
{
    [HttpPost("generate")]
    public async Task<IActionResult> GeneratePdf([FromBody] PdfRequest documents)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for PDF generation request");
            return BadRequest(ModelState);
        }

        try
        {
            _logger.LogInformation("Received request to generate PDF for {DocumentCount} documents", documents.Documents.Count);
            await _pdfService.GeneratePdfAsync(documents);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while generating PDF");
            return StatusCode(500, "Internal server error");
        }
    }
}
