using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace FontAwesome.Generate;

public static partial class Formatting
{
    [GeneratedRegex("\\([^)]*\\)")] private static partial Regex GenerateMatchRegex();
    private static readonly Regex Match = GenerateMatchRegex();
    private const string Tab = "    ";

    public static void AppendIndented(this StringBuilder sb, string value)
    {
        foreach (string line in value.Split("\r\n")) {
            sb.AppendLine(Tab + line);
        }
    }

    public static string GetEnumName(string id)
    {
        if (id.EndsWith("-o") || id.Contains("-o-")) {
            id = id.Replace("-o", "-outline");
        }

        var sb = new StringBuilder(
            Thread.CurrentThread.CurrentCulture?.TextInfo.ToTitleCase(id)
        );

        sb.Replace("/", "_")
            .Replace("-", string.Empty)
            .Replace(" ", string.Empty)
            .Replace(".", string.Empty)
            .Replace("'", string.Empty);
        
        string str = sb.ToString();
        MatchCollection matches = Match.Matches(str);
        sb = new StringBuilder(Match.Replace(str, string.Empty));

        if (matches.Where(x => x.Value.IndexOf("Hand", StringComparison.CurrentCultureIgnoreCase) > -1).Any()) {
            sb.Insert(0, "Hand");
        }

        if (sb.Length > 0 && char.IsDigit(sb[0])) {
            sb.Insert(0, '_');
        }

        return sb.ToString();
    }
}