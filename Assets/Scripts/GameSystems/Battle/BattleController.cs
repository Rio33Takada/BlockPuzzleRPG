using System.Collections.Generic;

public class BattleController
{
    private readonly BattleStateMachine stateMachine;
    private readonly BattleContext context;

    public BattleController(
        GridManager<FieldGridInformation> fieldGrid,
        GridManager<PuzzleGridInformation> puzzleGrid,
        List<BattleEnemy> enemies,
        List<BattleCharacter> playerTeam
    )
    {
        context = new BattleContext(
            fieldGrid,
            puzzleGrid,
            enemies,
            playerTeam
        );

        stateMachine = CreateStateMachine(context);
    }

    public void StartBattle()
    {
        stateMachine.Start();
    }

    public void Update()
    {
        stateMachine.Update();
    }

    private BattleStateMachine CreateStateMachine(BattleContext context)
    {
        var states = new Dictionary<BattleState, IBattleState>
        {
            { BattleState.Initialize, new InitializeState(context, this) },
            { BattleState.StartTurn, new StartTurnState(context, this) },
            { BattleState.PlayerInput, new PlayerInputState(context, this) },
            { BattleState.PuzzleResolving, new PuzzleResolvingState(context, this) },
            { BattleState.EnemyTurn, new EnemyTurnState(context, this) },
            //{ BattleState.TurnEnd, new TurnEndState(context, this) },
            //{ BattleState.Victory, new VictoryState(context) },
            //{ BattleState.Defeat, new DefeatState(context) }
        };

        return new BattleStateMachine(states);
    }

    // èÛë‘ëJà⁄ÇÕ Controller åoóRÇ≈ÇÃÇ›çsÇ§
    public void ChangeState(BattleState next)
    {
        stateMachine.ChangeState(next);
    }
}
