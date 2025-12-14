using UnityEngine;

public class MagnifyingGlass : BaseItem
{
    private WorldState worldState;
    

    public override void AddToPlayer(WorldState wS)
    {
        worldState = wS;
        worldState.playerStats.ModifyStatMultiplicative(StatType.CritChance, 1.15f);
    }


}
