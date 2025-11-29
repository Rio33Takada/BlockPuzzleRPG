using UnityEngine;

public class FieldGenerator
{
    private readonly FieldViewFactory _viewFactory;
    private readonly Transform _parent;

    public FieldGenerator(FieldViewFactory viewFactory)
    {
        _viewFactory = viewFactory;
    }

    public GridManager<FieldGridInformation> GenerateField(DungeonStageData stageData)
    {
        var grid = new GridManager<FieldGridInformation>(stageData.Width, stageData.Height);

        foreach (var obj in stageData.FieldObjects)
        {
            var fieldObject = FieldObjectFactory.Create(obj.Type, obj.X, obj.Y);
            grid.SetGrid(obj.X, obj.Y, new FieldGridInformation(obj.X, obj.Y, fieldObject));

            // 見た目生成
            var worldPos = new Vector3(obj.X, 0, obj.Y); // ※適宜グリッドスケール変換を挟む
            _viewFactory.CreateView(fieldObject, _parent, worldPos);
        }

        return grid;
    }
}
