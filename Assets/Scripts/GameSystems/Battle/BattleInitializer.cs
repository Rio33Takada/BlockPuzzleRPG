using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトル開始時の処理を担当するクラス.
/// </summary>
public class BattleInitializer
{
    private readonly string characterPath;
    private readonly string enemyPath;
    private readonly string dungeonPath;

    public BattleInitializer(string enemyPath, string dungeonPath, string characterPath)
    {
        this.enemyPath = enemyPath;
        this.dungeonPath = dungeonPath;
        this.characterPath = characterPath;
    }

    public (
        GridManager<FieldGridInformation>, 
        GridManager<PuzzleGridInformation>, 
        List<BattleEnemy>
        ) 
        InitializeBattle(
        string stageId,
        FieldViewFactory fieldViewFactory,
        PuzzleViewFactory puzzleViewFactory,
        Transform fieldParent,
        Transform puzzleParent
        )
    {
        // ダンジョン情報を取得.
        DungeonDataLoader dungeonLoader = new DungeonDataLoader(dungeonPath);
        DungeonStageData stageData = dungeonLoader.LoadStage(stageId);

        // キャラデータベース取得.
        CharacterDatabase characterDB = new CharacterDatabase(characterPath);

        // 敵データベース取得.
        EnemyDatabase enemyDB = new EnemyDatabase(enemyPath);

        // フィールド生成準備.
        FieldGenerator fieldGenerator = new FieldGenerator(fieldViewFactory, fieldParent);

        // フィールド生成.
        GridManager<FieldGridInformation> field = fieldGenerator.GenerateField(stageData);

        // 戦闘キャラ生成.
        BattleCharacterFactory characterFactory = new BattleCharacterFactory(characterDB);

        // 敵生成.
        BattleEnemyFactory enemyFactory = new BattleEnemyFactory(enemyDB);
        EnemySpawner spawner = new EnemySpawner(field, enemyFactory, fieldViewFactory, fieldParent);
        List<BattleEnemy> enemies = spawner.SpawnEnemies(stageData.EnemySpawns);

        // 盤面生成準備.
        PuzzleGenerator puzzleGenerator = new PuzzleGenerator(puzzleViewFactory, puzzleParent);

        // 盤面生成.
        GridManager<PuzzleGridInformation> puzzle = puzzleGenerator.GeneratePuzzle(stageData);

        return (field, puzzle, enemies);
    }
}