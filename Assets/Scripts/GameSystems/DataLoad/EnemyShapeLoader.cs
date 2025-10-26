using System.Collections.Generic;

class EnemyShapeLoader
{
    private readonly Dictionary<string, EnemyShapeData> shapes = new Dictionary<string, EnemyShapeData>();

    public EnemyShapeLoader()
    {
        // 仮データ（後でJSON化可）
        shapes["ENEMY_SLIME"] = new EnemyShapeData
        {
            EnemyId = "ENEMY_SLIME",
            RelativeCells = new List<(int x, int y)>() { (0, 0) } // 1マス敵
        };

        shapes["ENEMY_GOLEM"] = new EnemyShapeData
        {
            EnemyId = "ENEMY_GOLEM",
            RelativeCells = new List<(int x, int y)>() { (0, 0), (1, 0), (0, 1), (1, 1) } // 2x2
        };
    }

    public EnemyShapeData GetShape(string enemyId)
        => shapes.ContainsKey(enemyId) ? shapes[enemyId] : null;
}
