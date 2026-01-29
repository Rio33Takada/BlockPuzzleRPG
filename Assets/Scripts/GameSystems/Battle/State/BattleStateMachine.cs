using System.Collections.Generic;

public class BattleStateMachine
{
    public BattleState CurrentState { get; private set; }

    private readonly Dictionary<BattleState, IBattleState> states;

    public BattleStateMachine(Dictionary<BattleState, IBattleState> states)
    {
        this.states = states;
    }

    public void Start()
    {
        ChangeState(BattleState.Initialize);
    }

    public void ChangeState(BattleState next)
    {
        states[CurrentState]?.Exit();
        CurrentState = next;
        states[CurrentState].Enter();
    }

    public void Update()
    {
        states[CurrentState]?.Update();
    }
}
