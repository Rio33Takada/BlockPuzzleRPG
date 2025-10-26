using System;
using System.Collections.Generic;

class EnemySpawner
{
    private readonly BattleEnemyFactory enemyFactory;
    private readonly GridManager<FieldGridInformation> fieldGrid;

    public EnemySpawner(GridManager<FieldGridInformation> grid, BattleEnemyFactory factory)
    {
        fieldGrid = grid;
        enemyFactory = factory;
    }

    public List<BattleEnemy> SpawnEnemies(List<EnemySpawnData> enemySpawns)
    {
        var enemies = new List<BattleEnemy>();

        foreach (var spawn in enemySpawns)
        {
            var enemy = enemyFactory.Create(spawn.EnemyId);
            bool placed = enemy.PlaceOnGrid(fieldGrid, spawn.X, spawn.Y);

            if (!placed)
                Console.WriteLine($"[SpawnError] {spawn.EnemyId} ÇÃîzíuÇ…é∏îsÇµÇ‹ÇµÇΩÅB");

            enemies.Add(enemy);
        }

        return enemies;
    }
}
