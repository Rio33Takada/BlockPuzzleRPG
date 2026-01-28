using System;
using System.Collections.Generic;
using System.IO;

public class EnemyDatabase
{
    private readonly Dictionary<int, EnemyData> enemies = new Dictionary<int, EnemyData>();

    public EnemyDatabase(string directoryPath)
    {
        LoadAll(directoryPath);
    }

    private void LoadAll(string dir)
    {
        if (!Directory.Exists(dir))
            throw new DirectoryNotFoundException($"Enemy directory not found: {dir}");

        string[] files = Directory.GetFiles(dir, "*.json");
        foreach (string file in files)
        {
            EnemyData data = JsonUtilityExtensions.LoadJson<EnemyData>(file);
            if (data != null && data.Id > 0)
            {
                enemies[data.Id] = data;
            }
            else
            {
                // ログまたは例外処理: 無効なデータ検出
                Console.WriteLine($"[EnemyDatabase] invalid or empty enemy data: {file}");
            }
        }
    }

    public EnemyData Get(int id)
    {
        EnemyData data;
        enemies.TryGetValue(id, out data);
        return data;
    }
}
