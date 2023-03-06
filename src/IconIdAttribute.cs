using System.Diagnostics.CodeAnalysis;

namespace FontAwesome.WPF;


[AttributeUsage(AttributeTargets.Field)]
public class IconIdAttribute : Attribute
{
    public required string Id { get; set; }

    [SetsRequiredMembers]
    public IconIdAttribute(string id)
    {
        Id = id;
    }
}
