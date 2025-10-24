class BattleTurnController
{
    private readonly PlayerTurnController playerTurn;
    private readonly EnemyTurnController enemyTurn;

    public bool IsPlayerTurn { get; private set; }

    public void StartPlayerTurn()
    {
        IsPlayerTurn = true;
        playerTurn.ExecuteTurn();
    }

    public void StartEnemyTurn()
    {
        IsPlayerTurn = false;
        enemyTurn.ExecuteTurn();
    }
}
