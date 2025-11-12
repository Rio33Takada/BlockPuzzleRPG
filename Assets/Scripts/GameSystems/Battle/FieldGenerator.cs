class FieldGenerator
{
    public GridManager<FieldGridInformation> GenerateField(DungeonStageData stageData)
    {
        var grid = new GridManager<FieldGridInformation>(stageData.Width, stageData.Height);

        foreach (var obj in stageData.FieldObjects)
        {
            var fieldObject = FieldObjectFactory.Create(obj.Type, obj.X, obj.Y);
            grid.SetGrid(obj.X, obj.Y, new FieldGridInformation(obj.X, obj.Y, fieldObject));
        }

        return grid;
    }
}