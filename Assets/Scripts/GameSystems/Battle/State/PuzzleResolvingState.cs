using UnityEngine;

public class PuzzleResolvingState : IBattleState
{
    private readonly BattleContext context;
    private readonly BattleController controller;

    private bool isResolved;

    public PuzzleResolvingState(BattleContext context, BattleController controller)
    {
        this.context = context;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("[Battle] Puzzle Resolving Start");

        isResolved = false;

        // 仮：即時解決（将来ここが非同期になる）
        ResolvePuzzle();
    }

    public void Update()
    {
        // 非同期対応用（今は空でOK）
        if (isResolved)
        {
            controller.ChangeState(BattleState.EnemyTurn);
        }
    }

    public void Exit()
    {
        Debug.Log("[Battle] Puzzle Resolving End");
    }

    private void ResolvePuzzle()
    {
        Debug.Log("[Battle] Puzzle Result Applied");

        // 将来ここに入る：
        // - 消去結果の集計
        // - ダメージ計算
        // - エフェクト再生開始

        isResolved = true;
    }
}
