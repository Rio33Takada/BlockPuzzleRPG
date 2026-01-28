using UnityEngine;

public class FieldObjectFactory
{
    public static FieldObject Create(FieldObjectType type, int x, int y)
    {
        switch (type)
        {
            case FieldObjectType.Empty:
                return new EmptyFieldObject(x, y);
            case FieldObjectType.OutSide:
                return new OutSideFieldObject(x, y);

            default:
                Debug.LogWarning($"Unknown field object type: {type}");
                return null;
        }
    }
}