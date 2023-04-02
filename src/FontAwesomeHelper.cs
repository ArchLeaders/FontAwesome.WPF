using FontAwesome.WPF.Models;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Media;

namespace FontAwesome.WPF;

using Icons = Dictionary<string, IconModel>;

public static class FontAwesomeHelper
{
    private static readonly int[] _supportedVersions = { 5, 6 };
    private static Icons _source = LoadEmbeded();

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

    /// <summary>
    /// Set the FontAwesome online source version:<br/>
    /// Supported versions: <b>5, 6</b><br/>
    /// <b>Note:</b> an internet connection is required to set the version
    /// </summary>
    /// <param name="version"></param>
    public static async Task SetVersion(int version = 6)
    {
        if (!_supportedVersions.Contains(version)) {
            throw new ArgumentException("FontAwesome: Invalid version specified during initialization", nameof(version));
        }

        await LoadFromUrl($"https://raw.githubusercontent.com/FortAwesome/Font-Awesome/{version}.x/metadata/icons.json");
    }

    public static async Task LoadFromUrl(string url)
    {
        using HttpClient client = new();
        using Stream stream = await client.GetStreamAsync(url);
        _source = (await JsonSerializer.DeserializeAsync<Icons>(stream))!;
    }

    public static void LoadFromFile(string path) => LoadFromData(File.ReadAllBytes(path).AsSpan());
    public static void LoadFromData(Span<byte> data) => _source = JsonSerializer.Deserialize<Icons>(data)!;
    public static void LoadFromStream(Stream stream) => _source = JsonSerializer.Deserialize<Icons>(stream)!;

    private static Icons LoadEmbeded()
    {
        Stream stream = typeof(FontAwesomeHelper).Assembly.GetManifestResourceStream("FontAwesome.WPF.Data.Icons.json")!;
        return JsonSerializer.Deserialize<Icons>(stream)!;
    }
}
