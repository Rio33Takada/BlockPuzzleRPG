using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class CharacterData
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public CharacterType Type { get; set; }

    [JsonProperty("hp")]
    public int HP { get; set; }

    [JsonProperty("attack")]
    public int Attack { get; set; }
}