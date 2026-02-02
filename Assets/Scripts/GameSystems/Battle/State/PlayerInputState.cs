using UnityEngine;

public class PlayerInputState : IBattleState
{
    private readonly BattleContext context;
    private readonly BattleController controller;

    // 入力確定フラグ（最小構成）
    private bool isConfirmed;

    public PlayerInputState(BattleContext context, BattleController controller)
    {
        this.context = context;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("[Battle] Player Input Start");

        isConfirmed = false;

        // 将来ここに入る可能性：
        // - パズル入力有効化
        // - UI 表示
        // - カーソル初期化
    }

    public void Update()
    {
        // 今は仮：Enterキーで確定
        if (!isConfirmed && Input.GetKeyDown(KeyCode.Return))
        {
            ConfirmInput();
        }
    }

    public void Exit()
    {
        // 将来ここに入る可能性：
        // - 入力無効化
        // - UI 非表示
    }

    private void ConfirmInput()
    {
        isConfirmed = true;
        Debug.Log("[Battle] Player Input Confirmed");

        controller.ChangeState(BattleState.PuzzleResolving);
    }
}
