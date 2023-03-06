using System.Text.Json.Serialization;

namespace FontAwesome.Generate.Models;

public class AliasesModel
{
    [JsonPropertyName("names")]
    public List<string> Names { get; set; } = new();
}
