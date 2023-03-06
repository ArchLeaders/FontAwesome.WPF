using System.Text.Json.Serialization;

namespace FontAwesome.Generate.Models;

public class IconModel
{
    [JsonPropertyName("unicode")]
    public required string Unicode { get; set; }

    [JsonPropertyName("aliases")]
    public AliasesModel Aliases { get; set; } = new();
}