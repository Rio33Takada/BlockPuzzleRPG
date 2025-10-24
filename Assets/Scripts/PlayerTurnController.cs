class PlayerTurnController
{
    private readonly ActiveSkillHandler activeSkill;
    private readonly PiecePlacementHandler piecePlacement;
    private readonly PassiveSkillResolver passiveResolver;

    public void ExecuteTurn()
    {
        activeSkill.TryActivateAll();
        piecePlacement.HandlePlacement();
        passiveResolver.ResolveAll();
    }
}
