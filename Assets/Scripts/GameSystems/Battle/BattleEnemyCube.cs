public class BattleEnemyCube : FieldObject
{
    public BattleEnemy ParentEnemy { get; }
    public int X { get; }
    public int Y { get; }

    public BattleEnemyCube(BattleEnemy parent, int x, int y)
    {
        ParentEnemy = parent;
        X = x;
        Y = y;
    }

    public override void OnHit(int damage)
    {
        ParentEnemy.TakeDamage(damage);
    }
}
