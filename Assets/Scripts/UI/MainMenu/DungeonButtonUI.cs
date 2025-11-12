using UnityEngine;
using UnityEngine.UI;
using System;

public class DungeonButtonUI : MonoBehaviour
{
    [SerializeField] private Text label;
    [SerializeField] private Button button;

    private string dungeonId;
    private Action<string> onClicked;

    public void Initialize(string dungeonId, Action<string> onClicked)
    {
        this.dungeonId = dungeonId;
        this.onClicked = onClicked;

        label.text = $"Stage {dungeonId}";
        button.onClick.AddListener(() => onClicked?.Invoke(dungeonId));
    }
}
