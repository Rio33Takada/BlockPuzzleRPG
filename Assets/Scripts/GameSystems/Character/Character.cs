public abstract class Character
{
    public CharacterType Type { get; set; }

    public string Name { get; set; }

    public int Level { get; set; }

    public int Id { get; set; }

    public int HP { get; set; }

    public int Attack { get; set; }
}

public enum CharacterType
{
    test,
}