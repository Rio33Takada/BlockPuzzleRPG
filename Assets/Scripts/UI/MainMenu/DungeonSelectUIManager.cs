using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DungeonSelectUIManager : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private DungeonButtonUI buttonPrefab;

    private List<string> availableDungeons = new List<string>() { "1-1"};

    void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        foreach (var dungeonId in availableDungeons)
        {
            var btn = Instantiate(buttonPrefab, buttonParent);
            btn.Initialize(dungeonId, OnDungeonButtonClicked);
        }
    }

    private void OnDungeonButtonClicked(string dungeonId)
    {
        Debug.Log($"Dungeon Selected: {dungeonId}");
        DungeonSceneManager.Instance.StartDungeon(dungeonId);
    }
}