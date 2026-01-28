using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleViewFactory : MonoBehaviour
{
    [System.Serializable]
    public class PuzzlePrefabEntry
    {
        public PuzzleObjectType type;
        public GameObject prefab;
    }

    [SerializeField]
    private List<PuzzlePrefabEntry> prefabEntries;

    private readonly Dictionary<PuzzleObjectType, GameObject> prefabMap = new Dictionary<PuzzleObjectType, GameObject>();

    private void Awake()
    {
        foreach (var entry in prefabEntries)
            prefabMap[entry.type] = entry.prefab;
    }

    public GameObject CreateView(PuzzleObject puzzleObject, Transform parent, Vector3 position)
    {
        if (!prefabMap.TryGetValue(puzzleObject.ObjectType, out var prefab))
        {
            Debug.LogWarning($"No prefab registered for {puzzleObject.ObjectType}");
            return null;
        }

        var view = Instantiate(prefab, position, Quaternion.identity, parent);
        view.name = $"{puzzleObject.ObjectType}({puzzleObject.X},{puzzleObject.Y})";

        return view;
    }
}
