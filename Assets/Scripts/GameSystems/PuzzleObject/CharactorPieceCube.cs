public class CharactorPieceCube : PuzzleObject
{
    public BattleCharacter ParentCharacter { get; private set; } // 攻撃力・属性を参照するキャラクター.

    // 親ピース.

    public CharactorPieceCube(BattleCharacter parent, int x, int y) : base(PuzzleObjectType.Cube, x, y)
    {
        ParentCharacter = parent;
    }
}
