using UnityEngine;

public class DungeonSceneManager : MonoBehaviour
{
    public static DungeonSceneManager Instance { get; private set; }

    [SerializeField] private FieldViewFactory fieldViewFactory;
    [SerializeField] private PuzzleViewFactory puzzleViewFactory;
    [SerializeField] private Transform fieldParent;
    [SerializeField] private Transform puzzleParent;

    private BattleInitializer battleInitializer;

    void Awake()
    {
        Instance = this;

        battleInitializer = new BattleInitializer(
            Application.dataPath + "/JsonData/Enemies",
            Application.dataPath + "/JsonData/Dungeons/",
            Application.dataPath + "/JsonData/Characters");
    }

    public void StartDungeon(string dungeonId)
    {
        var (field, puzzle, enemies) = battleInitializer.InitializeBattle(dungeonId, fieldViewFactory, puzzleViewFactory, fieldParent, puzzleParent);
        BattleController battleManager = new BattleController(field, puzzle, null, enemies, );
        battleManager.StartBattle();
    }
}