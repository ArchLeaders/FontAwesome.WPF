using FontAwesome.WPF.Models;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Media;

namespace FontAwesome.WPF;

using Icons = Dictionary<string, IconModel>;

public static class FontAwesomeHelper
{
    private static readonly int[] _supportedVersions = { 5, 6 };
    private static Icons _source = GetIconsFromSourceSync( // Default to v6
        "https://raw.githubusercontent.com/FortAwesome/Font-Awesome/6.x/metadata/icons.json");

    /// <summary>
    /// Set the FontAwesome source version:<br/>
    /// Supported versions: <b>5, 6</b>
    /// </summary>
    /// <param name="version"></param>
    public static async Task SetVersion(int version = 6)
    {
        if (!_supportedVersions.Contains(version)) {
            throw new ArgumentException("FontAwesome: Invalid version specified during initialization", nameof(version));
        }

        _source = await GetIconsFromSource(
            $"https://raw.githubusercontent.com/FortAwesome/Font-Awesome/{version}.x/metadata/icons.json");
    }

    public static bool TryGetIcon(string name, string type, out Geometry data, bool throwIfNotFound = true)
    {
        if (_source.TryGetValue(name.ToLower(), out IconModel? icon) == true) {
            if (!icon.Styles.Contains(type)) {
                type = icon.Styles[0];
            }

            data = Geometry.Parse(icon.Svg[type].Path);
            return true;
        }
        else if (throwIfNotFound) {
            throw new KeyNotFoundException($"The icon '{name}' does not exists");
        }

        data = Geometry.Empty;
        return false;
    }

    private static async Task<Icons> GetIconsFromSource(string url)
    {
        using HttpClient client = new();
        using Stream stream = await client.GetStreamAsync(url);
        return (await JsonSerializer.DeserializeAsync<Icons>(stream))!;
    }

    // Should only be used for
    // the field initialization
    private static Icons GetIconsFromSourceSync(string url)
    {
        using HttpClient client = new();
        using Stream stream = client.GetStreamAsync(url).Result;
        return JsonSerializer.Deserialize<Icons>(stream)!;
    }
}
