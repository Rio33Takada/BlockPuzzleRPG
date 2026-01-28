using System;
using System.Collections.Generic;
using System.IO;

public class CharacterDatabase
{
    private readonly Dictionary<int, CharacterData> characters = new Dictionary<int, CharacterData>();

    public CharacterDatabase(string directoryPath)
    {
        LoadAll(directoryPath);
    }

    private void LoadAll(string dir)
    {
        if (!Directory.Exists(dir))
            throw new DirectoryNotFoundException($"Character directory not found: {dir}");

        string[] files = Directory.GetFiles(dir, "*.json");
        foreach (string file in files)
        {
            CharacterData data = JsonUtilityExtensions.LoadJson<CharacterData>(file);

            if (data != null && data.Id > 0)
            {
                characters[data.Id] = data;
            }
            else
            {
                Console.WriteLine($"[CharacterDatabase] invalid or empty character data: {file}");
            }
        }
    }

    public CharacterData Get(int id)
    {
        characters.TryGetValue(id, out var data);
        return data;
    }

    public IEnumerable<CharacterData> GetAll()
    {
        return characters.Values;
    }
}
