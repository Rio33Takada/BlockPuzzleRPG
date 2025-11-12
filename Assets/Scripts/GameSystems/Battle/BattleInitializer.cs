using System.Collections.Generic;

/// <summary>
/// バトル開始時の処理を担当するクラス.
/// </summary>
public class BattleInitializer
{
    private readonly string enemyPath;
    private readonly string dungeonPath;

    public BattleInitializer(string enemyPath, string dungeonPath)
    {
        this.enemyPath = enemyPath;
        this.dungeonPath = dungeonPath;
    }

    public (GridManager<FieldGridInformation>, List<BattleEnemy>) InitializeBattle(string stageId)
    {
        DungeonDataLoader dungeonLoader = new DungeonDataLoader(dungeonPath);
        DungeonStageData stageData = dungeonLoader.LoadStage(stageId);

        EnemyDatabase enemyDB = new EnemyDatabase(enemyPath);
        FieldGenerator fieldGenerator = new FieldGenerator();
        GridManager<FieldGridInformation> field = fieldGenerator.GenerateField(stageData);

        BattleEnemyFactory factory = new BattleEnemyFactory(enemyDB);
        EnemySpawner spawner = new EnemySpawner(field, factory);

        List<BattleEnemy> enemies = spawner.SpawnEnemies(stageData.EnemySpawns);

        return (field, enemies);
    }
}