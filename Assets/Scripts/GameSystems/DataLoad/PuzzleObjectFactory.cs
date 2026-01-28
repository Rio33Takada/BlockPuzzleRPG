using UnityEngine;

public class PuzzleObjectFactory
{
    public static PuzzleObject Create(PuzzleObjectType type, int x, int y)
    {
        switch (type)
        {
            case PuzzleObjectType.Empty:
                return new EmptyPuzzleObject(x, y);
            case PuzzleObjectType.OutSide:
                return new OutSidePuzzleObject(x, y);
            default:
                return null;
        }
    }
}
