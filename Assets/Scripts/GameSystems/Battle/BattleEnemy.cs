using UnityEngine;
using System.Collections.Generic;

public class BattleEnemy
{
    public Enemy EnemyData { get; }
    public List<BattleEnemyCube> Cubes { get; }
    private EnemyShapeData shapeData;

    public BattleEnemy(Enemy data, List<BattleEnemyCube> cubes)
    {
        EnemyData = data;
        Cubes = cubes;
    }

    public void SetShapeData(EnemyShapeData data)
    {
        shapeData = data;
    }

    public bool PlaceOnGrid(GridManager<FieldGridInformation> grid, int startX, int startY)
    {
        if (shapeData == null)
        {
            Debug.LogError($"{EnemyData.Name} none ShapeData");
            return false;
        }

        foreach (var (dx, dy) in shapeData.RelativeCells)
        {
            int x = startX + dx;
            int y = startY + dy;

            if (!grid.IsInside(x, y)) 
            {
                Debug.LogError($"{EnemyData.Name} Outside");
                return false; // はみ出しチェック
            }
            if (!grid.GetGrid(x, y).FieldObject.IsEmpty)
            {
                Debug.LogError($"{EnemyData.Name} No Space To Place");
                return false; // 重複チェック
            }
        }

        foreach (var (dx, dy) in shapeData.RelativeCells)
        {
            int x = startX + dx;
            int y = startY + dy;
            var cube = new BattleEnemyCube(this, x, y);
            grid.GetGrid(x, y).FieldObject = cube;
            Cubes.Add(cube);
        }

        return true;
    }


    public void TakeDamage(int amount)
    {
        // hp--.
    }
}
