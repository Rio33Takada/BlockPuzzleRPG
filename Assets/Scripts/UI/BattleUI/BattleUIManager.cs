using System.Collections.Generic;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject characterUIPrefab;
    [SerializeField] private Transform characterUIParent;

    private void CreateCharacterUI(BattleCharacter character)
    {
        var ui = Instantiate(characterUIPrefab, characterUIParent);
    }

    public void CreatePlayerTeamUI(List<BattleCharacter> team)
    {
        foreach (BattleCharacter character in team)
        {
            CreateCharacterUI(character);
        }
    }
}
