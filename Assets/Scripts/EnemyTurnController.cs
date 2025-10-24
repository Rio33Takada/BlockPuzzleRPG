class EnemyTurnController
{
    private readonly EnemyAIModule aiModule;
    private readonly EnemyAttackExecutor attackExecutor;

    public void ExecuteTurn()
    {
        aiModule.CalculateAllEnemyMoves();
        attackExecutor.ExecuteAllAttacks();
    }
}
