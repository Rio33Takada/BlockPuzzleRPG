using System.Collections.Generic;

class DungeonStageData
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<EnemySpawnData> EnemySpawns { get; set; }
    public List<FieldObjectData> FieldObjects { get; set; }
}
