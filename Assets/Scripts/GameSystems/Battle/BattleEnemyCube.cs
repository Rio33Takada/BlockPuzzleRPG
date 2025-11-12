public class BattleEnemyCube : FieldObject
{
    public BattleEnemy ParentEnemy { get; }

    public BattleEnemyCube(BattleEnemy parent, int x, int y) : base (FieldObjectType.Enemy, x, y)
    {
        ParentEnemy = parent;
    }

    public override void OnHit(int damage)
    {
        ParentEnemy.TakeDamage(damage);
    }
}
