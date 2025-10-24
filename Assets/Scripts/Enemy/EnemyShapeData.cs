using System.Collections.Generic;

class EnemyShapeData
{
    public string EnemyId { get; set; }
    public List<(int offsetX, int offsetY)> RelativeCells { get; set; }
}
