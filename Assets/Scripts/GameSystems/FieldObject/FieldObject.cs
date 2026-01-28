public abstract class FieldObject
{
    public int X { get; }
    public int Y { get; }

    public FieldObjectType ObjectType { get; }

    public FieldObject(FieldObjectType objectType, int x, int y)
    {
        ObjectType = objectType;
        X = x;
        Y = y;
    }

    public bool IsEmpty => ObjectType == FieldObjectType.Empty;

    public virtual void OnHit(int damage)
    {

    }
}