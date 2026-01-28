using UnityEngine;

public class FieldGenerator
{
    private readonly FieldViewFactory _viewFactory;
    private readonly Transform _parent;

    public FieldGenerator(FieldViewFactory viewFactory, Transform parent)
    {
        _viewFactory = viewFactory;
        _parent = parent;
    }

    public GridManager<FieldGridInformation> GenerateField(DungeonStageData stageData)
    {
        // グリッド初期化.
        var fieldGrid = new GridManager<FieldGridInformation>(
            stageData.Width,
            stageData.Height,
            (x, y) =>
            {
                var fieldObj = FieldObjectFactory.Create(FieldObjectType.Empty, x, y);
                return new FieldGridInformation(x, y, fieldObj);
            }
        );

        // 空白マスの見た目生成.
        foreach (var g in fieldGrid.GetAll())
        {
            if (g.FieldObject.ObjectType == FieldObjectType.Empty)
            {
                var worldPos = new Vector3(g.IndexX, 0, g.IndexY);
                g.ViewObject = _viewFactory.CreateView(g.FieldObject, _parent, worldPos);
            }
        }

        // 初期配置オブジェクト生成.
        foreach (var obj in stageData.FieldObjects)
        {
            var fieldObject = FieldObjectFactory.Create(obj.Type, obj.X, obj.Y);
            fieldGrid.SetGrid(obj.X, obj.Y, new FieldGridInformation(obj.X, obj.Y, fieldObject));

            // 見た目生成
            var worldPos = new Vector3(obj.X, 0, obj.Y); // ※適宜グリッドスケール変換を挟む
            fieldGrid.GetGrid(obj.X, obj.Y).ViewObject = _viewFactory.CreateView(fieldObject, _parent, worldPos);
        }

        return fieldGrid;
    }
}
