/// <summary>
/// バトル中のキャラクターデータを持つクラス.
/// </summary>
public class BattleCharacter
{
    public Character CharacterData { get; }

    public BattleCharacter(Character data)
    {
        CharacterData = data;
    }


}
