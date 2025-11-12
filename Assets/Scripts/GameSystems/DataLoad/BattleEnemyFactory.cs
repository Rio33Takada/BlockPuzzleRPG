using System;
using System.Collections.Generic;

public class BattleEnemyFactory
{
    private readonly EnemyDatabase enemyDB;

    public BattleEnemyFactory(EnemyDatabase db)
    {
        enemyDB = db;
    }

    public BattleEnemy Create(string enemyId)
    {
        EnemyData data = enemyDB.Get(enemyId);
        if (data == null)
        {
            Console.WriteLine($"[BattleEnemyFactory] Enemy not found: {enemyId}");
            return null;
        }

        List<(int, int)> shapeCells = new List<(int, int)>();
        if (data.Shape != null)
        {
            foreach (int[] pair in data.Shape)
            {
                if (pair.Length >= 2)
                {
                    shapeCells.Add((pair[0], pair[1]));
                }
            }
        }

        Enemy enemy = new Enemy
        {
            //Id = data.Id,
            //HP = data.HP,
            //Attack = data.Attack
        };

        EnemyShapeData shape = new EnemyShapeData
        {
            EnemyId = data.Id,
            RelativeCells = shapeCells
        };

        BattleEnemy battleEnemy = new BattleEnemy(enemy, new List<BattleEnemyCube>());
        battleEnemy.SetShapeData(shape);

        return battleEnemy;
    }
}
