using Newtonsoft.Json;

public class EnemySpawnData
{
    [JsonProperty("enemyId")]
    public int EnemyId { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}
