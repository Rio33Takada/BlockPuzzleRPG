class FieldGenerator
{
    public GridManager<FieldGridInformation> GenerateField(DungeonStageData stageData)
    {
        var grid = new GridManager<FieldGridInformation>(stageData.Width, stageData.Height);

        foreach (var obj in stageData.FieldObjects)
        {
            var fieldObject = FieldObjectFactory.Create(obj.Type);
            grid.SetGrid(obj.X, obj.Y, new FieldGridInformation
            {
                FieldObject = fieldObject,
                IndexX = obj.X,
                IndexY = obj.Y
            });
        }

        return grid;
    }
}
