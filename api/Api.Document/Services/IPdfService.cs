using Api.Document.Models;

namespace Api.Document.Services;

public interface IPdfService
{
    Task GeneratePdfAsync(PdfRequest documents);
}
