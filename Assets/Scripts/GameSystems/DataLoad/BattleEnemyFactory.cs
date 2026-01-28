using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyFactory
{
    private readonly EnemyDatabase enemyDB;
    private readonly Dictionary<EnemyType, Func<Enemy>> creators =
        new Dictionary<EnemyType, Func<Enemy>>()
        {
            { EnemyType.test, () => new TestEnemy() }
        };

    public BattleEnemyFactory(EnemyDatabase db)
    {
        enemyDB = db;
    }

    public BattleEnemy Create(int enemyId)
    {
        EnemyData data = enemyDB.Get(enemyId);
        if (data == null)
        {
            Debug.LogWarning($"[BattleEnemyFactory] Enemy not found: {enemyId}");
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

        Enemy enemy = CreateEnemy(enemyId);

        EnemyShapeData shape = new EnemyShapeData
        {
            EnemyId = data.Id,
            RelativeCells = shapeCells
        };

        BattleEnemy battleEnemy = new BattleEnemy(enemy, new List<BattleEnemyCube>());
        battleEnemy.SetShapeData(shape);

        return battleEnemy;
    }

    public Enemy CreateEnemy(int enemyId)
    {
        EnemyData data = enemyDB.Get(enemyId);
        if (data == null)
            return null;

        if (!creators.TryGetValue(data.Type, out var creator))
            throw new System.Exception($"EnemyType not registered: {data.Type}");

        Enemy enemy = creator();

        enemy.Id = data.Id;
        enemy.Name = data.Name;
        enemy.HP = data.HP;
        enemy.Attack = data.Attack;
        enemy.Type = data.Type;

        return enemy;
    }
}
