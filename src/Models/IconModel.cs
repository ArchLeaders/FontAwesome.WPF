using System.Text.Json.Serialization;

namespace FontAwesome.WPF.Models;

public class IconModel
{
    public string this[string brand] {
        get => Svg[brand].Path;
    }

    [JsonPropertyName("unicode")]
    public required string Unicode { get; set; }

    [JsonPropertyName("svg")]
    public required Dictionary<string, SvgModel> Svg { get; set; }

    [JsonPropertyName("styles")]
    public required List<string> Styles { get; set; }

    public class SvgModel
    {
        [JsonPropertyName("path")]
        public required string Path { get; set; }
    }
}
