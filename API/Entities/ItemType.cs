using System.Diagnostics.CodeAnalysis;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class ItemType
{
    public int Id { get; set; }
    public string Type { get; set; }
}