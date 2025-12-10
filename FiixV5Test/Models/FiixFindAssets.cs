using System.Text.Json.Serialization;

namespace FiixV5Test;

public record class FiixFindAssets
{
    [JsonPropertyName("_maCn")]
    public string? RequestType { get; } = "FindRequest";
    [JsonPropertyName("clientVersion")]
    public FiixClientVersion? ClVersion { get; } = new FiixClientVersion();
    [JsonPropertyName("className")]
    public string? ClassName { get; } = "Asset";
    [JsonPropertyName("fields")]
    public string? Fields { get; } = "*";
}
