using Newtonsoft.Json;
using System.Collections.Generic;

public class EnemyData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("hp")]
    public int HP { get; set; }

    [JsonProperty("attack")]
    public int Attack { get; set; }

    // JSONì‡ÇÃ shape: [[0,0],[1,0],...] Çì«Ç›çûÇﬁ
    [JsonProperty("shape")]
    public List<int[]> Shape { get; set; }
}
