using UnityEngine;
using System.Collections.Generic;

public class FieldViewFactory : MonoBehaviour
{
    [System.Serializable]
    public class FieldPrefabEntry
    {
        public FieldObjectType type;
        public GameObject prefab;
    }

    [SerializeField]
    private List<FieldPrefabEntry> prefabEntries;

    private readonly Dictionary<FieldObjectType, GameObject> prefabMap = new Dictionary<FieldObjectType, GameObject>();

    private void Awake()
    {
        foreach (var entry in prefabEntries)
            prefabMap[entry.type] = entry.prefab;
    }

    public GameObject CreateView(FieldObject fieldObject, Transform parent, Vector3 position)
    {
        if (!prefabMap.TryGetValue(fieldObject.ObjectType, out var prefab))
        {
            Debug.LogWarning($"No prefab registered for {fieldObject.ObjectType}");
            return null;
        }

        var view = Instantiate(prefab, position, Quaternion.identity, parent);
        view.name = $"{fieldObject.ObjectType}({fieldObject.X},{fieldObject.Y})";
        return view;
    }
}
