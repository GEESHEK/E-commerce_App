using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    [JsonIgnore]
    public string PublicId { get; set; }
    [JsonIgnore]
    public int WatchId { get; set; }
    [JsonIgnore]
    public Watch Watch { get; set; }
}