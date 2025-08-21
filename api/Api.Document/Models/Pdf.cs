using System.Text.Json.Serialization;

namespace Api.Document.Models;

public class PdfRequest
{
    [JsonPropertyName("documents")]
    public List<Pdf> Documents { get; set; } = null!;
}

public class Pdf
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("template")]
    public string Template { get; set; } = null!;

    [JsonPropertyName("send")]
    public bool? Send { get; set; }

    [JsonPropertyName("parameters")]
    public List<Dictionary<string, object>> Parameters { get; set; } = [];

    [JsonPropertyName("images")]
    public List<Dictionary<string, string>> Images { get; set; } = [];
}
