using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FiixV5Test;

public record class FiixAddRequest
{
    [JsonPropertyName("_maCn")]
    public string RequestType { get; } = "AddRequest";

    [JsonPropertyName("clientVersion")]
    public FiixClientVersion ClVersion { get; } = new FiixClientVersion();

    [JsonPropertyName("className")]
    public required string ClassName { get; set; }

    [JsonPropertyName("fields")]
    public required string Fields { get; set; }

    [JsonPropertyName("object")]
    public required dynamic NewObject { get; set; }
}
