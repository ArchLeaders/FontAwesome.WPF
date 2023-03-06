using Microsoft.CodeAnalysis;

namespace FontAwesome.Generate;

#if DEBUG
internal static class Log
{
    private static readonly List<string> _logs = new();

    public static void Flush(GeneratorExecutionContext context)
    {
        context.AddSource($"Logs.g.cs", string.Join("\n", _logs));
    }

    public static void Print(string msg)
    {
        _logs.Add("// " + msg);
    }
}
#endif
