using UnityEngine;

public class PuzzleGridInformation : BaseGridInformation
{
    public PuzzleObject PuzzleObject { get; set; }
    public GameObject ViewObject { get; set; }

    public PuzzleGridInformation(int x, int y, PuzzleObject puzzleObject)
        : base(x, y)
    {
        PuzzleObject = puzzleObject;
    }

    public override void OnBeforeReplace()
    {
        if (ViewObject != null)
        {
            GameObject.Destroy(ViewObject);
            ViewObject = null;
        }
    }
}
