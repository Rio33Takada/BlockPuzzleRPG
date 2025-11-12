using UnityEngine;

public class DungeonSceneManager : MonoBehaviour
{
    public static DungeonSceneManager Instance { get; private set; }

    private BattleInitializer battleInitializer;

    void Awake()
    {
        Instance = this;
        battleInitializer = new BattleInitializer(
            Application.dataPath + "/Data/Enemies", 
            Application.dataPath + "/Data/Dungeons/");
    }

    public void StartDungeon(string dungeonId)
    {
        battleInitializer.InitializeBattle(dungeonId);
    }
}