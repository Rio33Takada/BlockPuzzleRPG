using System.Collections.Generic;

class BattleManager
{
    private readonly BattleTurnController turnController;
    private readonly GridManager<FieldGridInformation> fieldGrid;
    private readonly GridManager<PuzzleGridInformation> puzzleGrid;
    private readonly List<BattleCharacter> playerTeam;
    private readonly List<BattleEnemy> enemies;

    public BattleManager(
        GridManager<FieldGridInformation> fieldGridManager,
        GridManager<PuzzleGridInformation> puzzleGridManager,
        List<BattleEnemy> enemiesList
        )
    {
        fieldGrid = fieldGridManager;
        puzzleGrid = puzzleGridManager;
        enemies = enemiesList;

        turnController = new BattleTurnController();
    }

    public void StartBattle()
    {
        turnController.StartPlayerTurn();
    }

    //public void EndTurn()
    //{
    //    if (turnController.IsPlayerTurn)
    //        turnController.StartEnemyTurn();
    //    else
    //        turnController.StartPlayerTurn();
    //}
}
