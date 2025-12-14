using UnityEngine;

public class MagnifyingGlass : BaseItem
{
    private WorldState worldState;
    public GameObject projectilePrefab;

    public override void AddToPlayer(WorldState wS)
    {
        worldState = wS;
        worldState.playerStats.ModifyStatMultiplicative(StatType.CritMultiplier, 1.15f);
    }


}
