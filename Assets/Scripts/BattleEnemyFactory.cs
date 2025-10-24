using System.Collections.Generic;

class BattleEnemyFactory
{
    private readonly EnemyShapeLoader shapeLoader = new EnemyShapeLoader();

    public BattleEnemy Create(string enemyId)
    {
        var enemyData = new Enemy { Id = enemyId, HP = 100, Attack = 10 };
        var shape = shapeLoader.GetShape(enemyId);

        var battleEnemy = new BattleEnemy(enemyData, new List<BattleEnemyCube>());
        battleEnemy.SetShapeData(shape);

        return battleEnemy;
    }
}
