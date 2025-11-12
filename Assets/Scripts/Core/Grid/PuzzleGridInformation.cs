using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGridInformation : BaseGridInformation
{
    public PuzzleObject PuzzleObject { get; set; }

    public PuzzleGridInformation(int x, int y, PuzzleObject puzzleObject) : base(x, y)
    {
        PuzzleObject = puzzleObject;
    }
}
