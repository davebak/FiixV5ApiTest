using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FiixV5Test;


public record class FiixSampleAsset
{
    [JsonPropertyName("strName")]
    public string Name { get; } = "SampleAsset99";
    [JsonPropertyName("strCode")]
    public string Code { get; } = "SampleCode99";
    [JsonPropertyName("className")]
    public string ClassName { get; } = "Asset";

}

public record class FiixNewSampleAsset
{
    [JsonPropertyName("_maCn")]
    public string RequestType { get; } = "AddRequest";
    [JsonPropertyName("clientVersion")]
    public FiixClientVersion ClVersion { get; } = new FiixClientVersion();
    [JsonPropertyName("className")]
    public string ClassName { get; } = "Asset";
    [JsonPropertyName("fields")]
    public string Fields { get; } = "*, id";
    [JsonPropertyName("object")]
    public FiixSampleAsset NewObject { get; } = new FiixSampleAsset();
}