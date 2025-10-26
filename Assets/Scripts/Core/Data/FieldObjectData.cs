using Newtonsoft.Json;

public class FieldObjectData
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}
