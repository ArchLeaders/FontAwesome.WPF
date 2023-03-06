using FontAwesome.Generate.Models;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace FontAwesome.Generate;

[Generator]
public class SourceGenerator : ISourceGenerator
{
    private const string BaseUrl = "https://fontawesome.com/v6/icons";
    private const string SourceUrl = "https://raw.githubusercontent.com/FortAwesome/Font-Awesome/6.x/metadata/icons.json";

    /// <summary>icon-id | <a href="">(source)</a></summary>
    /// <param name="context"></param>
    public void Execute(GeneratorExecutionContext context)
    {
        StringBuilder sb = new();
        GenerateItems(sb);

        string source = $$"""
            namespace FontAwesome.WPF;

            public enum FavouriteIcon
            {{{sb}}
            }
            """;

        context.AddSource("FavouriteIcon.g.cs", source);
        Log.Flush(context);
    }

    public static void GenerateItems(StringBuilder sb)
    {
        using var client = new HttpClient();
        Stream iconsFs = client.GetStreamAsync(SourceUrl).Result;
        var icons = JsonSerializer.Deserialize<Dictionary<string, IconModel>>(iconsFs)!;

        foreach ((var id, var icon) in icons) {
            sb.AppendIndented($"""

                /// <summary>
                /// {id} | <a href="{BaseUrl}/{id}">(source)</a>
                /// </summary>
                """);

            sb.AppendIndented($"""
                [IconId("{id}")]
                {Formatting.GetEnumName(id)} = 0x{icon.Unicode.ToUpper()},
                """);

            foreach (var name in icon.Aliases.Names) {
                sb.AppendIndented($"""

                /// <summary>
                /// {name} (alias of {id}) | <a href="{BaseUrl}/{id}">(source)</a>
                /// </summary>
                """);

                sb.AppendIndented($"""
                [IconId("{id}")]
                {Formatting.GetEnumName(name)} = 0x{icon.Unicode.ToUpper()},
                """);
            }
        }
    }

    public void Initialize(GeneratorInitializationContext context)
    {

    }
}