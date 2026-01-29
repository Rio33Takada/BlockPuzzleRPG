class BattleTurnController
{
    private readonly PlayerTurnController playerTurn;
    private readonly EnemyTurnController enemyTurn;

    public BattleTurnController()
    {

    }

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
