class BattleInitializer
{
    private readonly FieldGenerator fieldGenerator = new();
    private EnemySpawner enemySpawner;

    public (GridManager<FieldGridInformation>, List<BattleEnemy>) InitializeBattle(DungeonStageData stageData)
    {
        var field = fieldGenerator.GenerateField(stageData);
        enemySpawner = new EnemySpawner(field);

        var enemies = enemySpawner.SpawnEnemies(stageData.EnemySpawns);

        return (field, enemies);
    }
}
