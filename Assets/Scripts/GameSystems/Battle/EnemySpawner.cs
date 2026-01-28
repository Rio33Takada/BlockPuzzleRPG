using System;
using System.Collections.Generic;
using UnityEngine;
class EnemySpawner
{
    private readonly BattleEnemyFactory enemyFactory;
    private readonly GridManager<FieldGridInformation> fieldGrid;
    private readonly FieldViewFactory fieldViewFactory;
    private readonly Transform parent;

    public EnemySpawner(
        GridManager<FieldGridInformation> grid,
        BattleEnemyFactory factory,
        FieldViewFactory viewFactory,
        Transform parent
        )
    {
        fieldGrid = grid;
        enemyFactory = factory;
        fieldViewFactory = viewFactory;
        this.parent = parent;
    }

    public List<BattleEnemy> SpawnEnemies(List<EnemySpawnData> enemySpawns)
    {
        var enemies = new List<BattleEnemy>();

        foreach (var spawn in enemySpawns)
        {
            // 敵ロジック生成.
            var enemy = enemyFactory.Create(spawn.EnemyId);
            bool placed = enemy.PlaceOnGrid(fieldGrid, spawn.X, spawn.Y);

            if (!placed)
                Debug.LogWarning($"[SpawnError] {spawn.EnemyId} の配置に失敗しました。");
            else Debug.Log($"enemy{spawn.EnemyId} を配置しました。");

            foreach (var (offsetX, offsetY) in enemy.ShapeData.RelativeCells)
            {
                int x = spawn.X + offsetX;
                int y = spawn.Y + offsetY;
            }

            foreach (var cube in enemy.Cubes)
            {
                var worldPos = new Vector3(cube.X, 0, cube.Y);
                fieldViewFactory.CreateView(cube, parent, worldPos);
            }

            enemies.Add(enemy);
        }

        return enemies;
    }
}
