public enum PuzzleObjectType
{
    Empty,
    OutSide,
    Cube,
    Meltable,
    Unremovable,
}
public abstract class PuzzleObject
{
    public int X { get; }
    public int Y { get; }

    public PuzzleObjectType ObjectType { get; }

    public PuzzleObject(PuzzleObjectType type, int x, int y)
    {
        ObjectType = type;
        X = x;
        Y = y;
    }

    public bool IsEmpty => ObjectType == PuzzleObjectType.Empty;
}
