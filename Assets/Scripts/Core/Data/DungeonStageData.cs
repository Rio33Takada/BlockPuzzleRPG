using Newtonsoft.Json;
using System.Collections.Generic;

public class DungeonStageData
{
    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("enemySpawns")]
    public List<EnemySpawnData> EnemySpawns { get; set; }

    [JsonProperty("fieldObjects")]
    public List<FieldObjectData> FieldObjects { get; set; }
}
