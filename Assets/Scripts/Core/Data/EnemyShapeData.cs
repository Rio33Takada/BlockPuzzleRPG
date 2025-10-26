using System.Collections.Generic;

public class EnemyShapeData
{
    public string EnemyId { get; set; }
    public List<(int offsetX, int offsetY)> RelativeCells { get; set; }
}
