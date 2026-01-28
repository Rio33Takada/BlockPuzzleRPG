using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterFactory
{
    private readonly CharacterDatabase characterDB;
    private readonly Dictionary<CharacterType, Func<Character>> creators =
        new Dictionary<CharacterType, Func<Character>>()
        {
            {CharacterType.test, () => new TestCharacter() }
        };

    public BattleCharacterFactory(CharacterDatabase db)
    {
        characterDB = db;
    }

    public BattleCharacter Create(int characterId)
    {
        CharacterData data = characterDB.Get(characterId);
        if(data == null)
        {
            Debug.LogWarning($"[BattleCharacterFactory] Character not found: {characterId}");
            return null;
        }

        Character character = CreateCharacter(characterId);

        BattleCharacter battleCharacter = new BattleCharacter(character);

        return battleCharacter;
    }

    public Character CreateCharacter(int characterId)
    {
        CharacterData data = characterDB.Get(characterId);
        if (data == null)
            return null;
        if (!creators.TryGetValue(data.Type, out var creator))
            throw new System.Exception($"CharacterType not registered: {data.Type}");

        Character character = creator();

        character.Id = data.Id;
        character.Name = data.Name;
        character.HP = data.HP;
        character.Attack = data.Attack;
        character.Type = data.Type;

        return character;
    }
}
