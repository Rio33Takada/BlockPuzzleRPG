using System;
using System.IO;
using Newtonsoft.Json;

public static class JsonUtilityExtensions
{
    public static T LoadJson<T>(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"JSON file not found: {path}");

        string json = File.ReadAllText(path);

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        T result = JsonConvert.DeserializeObject<T>(json, settings);
        return result;
    }
}
