using UnityEngine;

public class StartTurnState : IBattleState
{
    private readonly BattleContext context;
    private readonly BattleController controller;

    public StartTurnState(BattleContext context, BattleController controller)
    {
        this.context = context;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Start Turn");
        controller.ChangeState(BattleState.PlayerInput);
    }

    public void Update() { }
    public void Exit() { }
}
