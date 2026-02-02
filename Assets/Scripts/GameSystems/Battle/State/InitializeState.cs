using UnityEngine;

public class InitializeState : IBattleState
{
    private readonly BattleContext context;
    private readonly BattleController controller;

    public InitializeState(BattleContext context, BattleController controller)
    {
        this.context = context;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("[Battle] Initialize");

        // 将来ここに初期化処理が増える可能性はあるが、
        // 今は「初期化完了 → StartTurn」だけでOK
        controller.ChangeState(BattleState.StartTurn);
    }

    public void Update()
    {
        // 何もしない（待たない）
    }

    public void Exit()
    {
        // 何もしない
    }
}
