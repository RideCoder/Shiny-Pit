using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player Stats")]
public class PlayerStatsData : ScriptableObject
{
    public List<Stat> baseStats = new();
}
