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
        Debug.Log("[Battle] Start Turn");

        // 将来ここに入る可能性があるもの：
        // - ターン数インクリメント
        // - バフ / デバフ更新
        // - 行動回数リセット
        // ただし今は何もしない

        // 即 PlayerInput へ
        controller.ChangeState(BattleState.PlayerInput);
    }

    public void Update()
    {
        // 待たない
    }

    public void Exit()
    {
        // 何もしない
    }
}
