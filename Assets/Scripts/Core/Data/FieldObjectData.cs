using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public enum FieldObjectType
{
    Empty,
    Enemy,
}

public class FieldObjectData
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public FieldObjectType Type { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}
