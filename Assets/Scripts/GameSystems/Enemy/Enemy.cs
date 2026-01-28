public abstract class Enemy
{
    public EnemyType Type { get; set; }

    public string Name { get; set; }

    public int Level { get; set; }

    public int Id { get; set; }

    public int HP { get; set; }

    public int Attack { get; set; }
}

public enum EnemyType
{
    test,
}
