using UnityEngine;

public class EnemyTurnState : IBattleState
{
    private readonly BattleContext context;
    private readonly BattleController controller;

    private int currentEnemyIndex;

    public EnemyTurnState(BattleContext context, BattleController controller)
    {
        this.context = context;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("[Battle] Enemy Turn Start");

        currentEnemyIndex = 0;

        ExecuteNextEnemy();
    }

    public void Update()
    {
        // 将来：アニメーション待ち・演出待ちなどをここで監視
    }

    public void Exit()
    {
        Debug.Log("[Battle] Enemy Turn End");
    }

    // ================================
    // 内部処理
    // ================================

    private void ExecuteNextEnemy()
    {
        if (currentEnemyIndex >= context.Enemies.Count)
        {
            // 全敵行動終了 → 次ターン
            controller.ChangeState(BattleState.StartTurn);
            return;
        }

        var enemy = context.Enemies[currentEnemyIndex];

        if (enemy.IsAlive)
        {
            ExecuteEnemyAction(enemy);
        }

        currentEnemyIndex++;
        ExecuteNextEnemy();
    }

    private void ExecuteEnemyAction(BattleEnemy enemy)
    {
        Debug.Log($"[Battle] Enemy Action: {enemy.EnemyData.Name}");

        // 仮実装：
        // enemy.AI.Decide(context);
        // enemy.Attack(target);

        // 今は即時処理でOK
    }
}
