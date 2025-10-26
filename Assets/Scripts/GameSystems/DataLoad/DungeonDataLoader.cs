using System.IO;

public class DungeonDataLoader
{
    private readonly string basePath;

    public DungeonDataLoader(string basePath)
    {
        this.basePath = basePath;
    }

    public DungeonStageData LoadStage(string stageId)
    {
        string path = Path.Combine(basePath, stageId + ".json");
        return JsonUtilityExtensions.LoadJson<DungeonStageData>(path);
    }
}
