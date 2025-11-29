using UnityEngine;

public class DungeonSceneManager : MonoBehaviour
{
    public static DungeonSceneManager Instance { get; private set; }

    [SerializeField] private FieldViewFactory viewFactory;
    [SerializeField] private Transform fieldParent;

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
        battleInitializer.InitializeBattle(dungeonId, viewFactory, fieldParent);
    }
}