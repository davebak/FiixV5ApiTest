using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FiixV5Test;

public record class FiixClientVersion
{
    [JsonPropertyName("major")]
    public int Major { get; } = 2;
    [JsonPropertyName("minor")]
    public int Minor { get; } = 8;
    [JsonPropertyName("patch")]
    public int Patch { get; } = 1;
}
