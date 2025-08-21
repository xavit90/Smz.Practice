using System;
using Api.Document.Models;

namespace Api.Document.Services;

public class PdfService : IPdfService
{
    private readonly ILogger<PdfService> _logger;
    private readonly string _inPath;
    private readonly string _outPath;

    public PdfService(ILogger<PdfService> logger)
    {
        _logger = logger;
        _inPath = Path.Combine(Directory.GetCurrentDirectory(), "pdf", "in");
        _outPath = Path.Combine(Directory.GetCurrentDirectory(), "pdf", "out");
    }

    public async Task GeneratePdfAsync(PdfRequest documents)
    {
        _logger.LogInformation("Generating PDF for {DocumentCount} documents", documents.Documents.Count);
        await Task.CompletedTask;
    }
}   