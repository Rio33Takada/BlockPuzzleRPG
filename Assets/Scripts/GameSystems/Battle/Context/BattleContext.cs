using System.Collections.Generic;

public class BattleContext
{
    public GridManager<FieldGridInformation> FieldGrid { get; }
    public GridManager<PuzzleGridInformation> PuzzleGrid { get; }
    public List<BattleEnemy> Enemies { get; }
    public List<BattleCharacter> PlayerTeam { get; }

    public BattleContext(
        GridManager<FieldGridInformation> fieldGrid,
        GridManager<PuzzleGridInformation> puzzleGrid,
        List<BattleEnemy> enemies,
        List<BattleCharacter> playerTeam = null
    )
    {
        FieldGrid = fieldGrid;
        PuzzleGrid = puzzleGrid;
        Enemies = enemies;
        PlayerTeam = playerTeam ?? new List<BattleCharacter>();
    }
}
