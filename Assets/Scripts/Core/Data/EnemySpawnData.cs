using Newtonsoft.Json;

public class EnemySpawnData
{
    [JsonProperty("enemyId")]
    public string EnemyId { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}
