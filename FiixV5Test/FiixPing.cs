using System.Text.Json.Serialization;

namespace FiixV5Test;

public record class FiixPing
{
    [JsonPropertyName("_maCn")]
    public string RequestType {get;} = "RpcRequest";
    [JsonPropertyName("clientVersion")]
    public FiixClientVersion ClVersion {get;} = new FiixClientVersion();
    [JsonPropertyName("name")]
    public string Name {get;} = "Ping";
    [JsonPropertyName("action")]
    public string Action {get;} = "Ping";
}
