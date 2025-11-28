using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FiixV5Test;

public class FiixMeterReading
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("intWorkOrderID")]
    public int? WorkOrderId { get; set; }

    [JsonPropertyName("intSubmittedByUserID")]
    public int? SubmittedByUserID { get; set; }

    [JsonPropertyName("intMeterReadingUnitsID")]
    public int? MeterReadingUnitsID { get; set; }

    [JsonPropertyName("dblMeterReading")]
    public double? MeterReading { get; set; }

    [JsonPropertyName("intAssetID")]
    public int? AssetID { get; set; }

    [JsonPropertyName("dtmDateSubmitted")]
    public string? DateSubmitted { get; set; }

    [JsonPropertyName("intUpdated")]
    public int? Updated { get; set; }

    [JsonPropertyName("strUuid")]
    public string? Uuid { get; set; }
}
