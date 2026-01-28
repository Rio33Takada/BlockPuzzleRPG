using UnityEngine;

public class PuzzleGenerator
{
    private readonly PuzzleViewFactory viewFactory;
    private readonly Transform parent;

    public PuzzleGenerator(PuzzleViewFactory viewFactory, Transform parent)
    {
        this.viewFactory = viewFactory;
        this.parent = parent;
    }

    public GridManager<PuzzleGridInformation> GeneratePuzzle(DungeonStageData stageData)
    {
        var puzzleGrid = new GridManager<PuzzleGridInformation>(
            stageData.Width,
            stageData.Height,
            (x, y) =>
            {
                var puzzleObj = new EmptyPuzzleObject(x, y);
                return new PuzzleGridInformation(x, y, puzzleObj);
            }
            );

        // ãÛîíÉ}ÉXÇÃå©ÇΩñ⁄ê∂ê¨.
        foreach (var g in puzzleGrid.GetAll())
        {
            Debug.Log((g.IndexX, g.IndexY));
            if (g.PuzzleObject.IsEmpty)
            {
                var worldPos = new Vector3(g.IndexX, 0, g.IndexY);
                g.ViewObject = viewFactory.CreateView(g.PuzzleObject, parent, worldPos);
            }

            foreach (var obj in stageData.FieldObjects)
            {
                if (obj.Type == FieldObjectType.OutSide)
                {
                    var puzzleObject = PuzzleObjectFactory.Create(PuzzleObjectType.OutSide, obj.X, obj.Y);
                }
            }
        }

        return puzzleGrid;
    }
}