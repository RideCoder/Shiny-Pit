using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public enum StatType
{
    FireRateMultiplier,
    DamageMultiplier,
    MovementMultiplier,
    Health,
    HealthRegen,
    ExtraJumps,
    JumpHeight,
    TileDamageMultiplier,
    XpMultiplier,
    Xp,
    XpRequired,
    CritChance,
    CritMultiplier
}


[Serializable]
public class Stat
{
    public StatType type;
    public float baseValue;
}
public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [Header("Base Data")]
    public PlayerStatsData baseStatsData;

    [Header("Runtime Stats")]
    public Dictionary<StatType, float> runtimeStats = new();
    /* public float fireRateMultiplier = 1f;
     public float damageMultiplier = 1f;
     public float movementMultipler = 1f;
     public float health = 100f;
     public float healthRegen = 1f;
     public float extraJumps = 0f;
     public float jumpHeight = 19f;
     public float tileDamageMultiplier = 1f;
     public float xpMultiplier = 1f;
     public float xp = 0f;
     public float xpRequired = 5f;
     public float critChance = 0.1f;
     public float critMultiplier = 2f;*/
    public int level = 0;

    public event Action OnPlayerStatUpdated;
    public event Action OnPlayerLevelUp;
    public event Action OnPlayerTouchStatBoost;

    public Slider slider;
   
    public WorldState worldState;

    private void Awake()
    {
        InitializeStats();
    }

    public void RaisePlayerTouchStatBoost()
    {
        OnPlayerTouchStatBoost?.Invoke();
    }

    private void InitializeStats()
    {
        runtimeStats.Clear();

        foreach (var stat in baseStatsData.baseStats)
        {
            runtimeStats[stat.type] = stat.baseValue;
            Debug.Log(stat.type);
        }
      

    }
    public void Start()
    {
        worldState.tilemapData.OnTileBroke += AddXp;

        slider.minValue = 0;
        slider.value = 0;
        slider.maxValue = GetStat(StatType.XpRequired);
    }

    public void AddXp(Tile tile)
    {
        if (tile is not DestructibleTile destructibleTile)
            return;

        ModifyStatAdditive(StatType.Xp, destructibleTile.xp);
        slider.value = GetStat(StatType.Xp);
    }


    public void Update()
    {
        float xp = GetStat(StatType.Xp);
        float xpRequired = GetStat(StatType.XpRequired);

        if (xp < xpRequired)
            return;

        xp -= xpRequired;
        level++;

        SetStat(StatType.Xp, xp);
        ModifyStatAdditive(StatType.XpRequired, 10f);

        slider.maxValue = GetStat(StatType.XpRequired);
        slider.value = xp;

        OnPlayerLevelUp?.Invoke();
    }


    public float GetStat(StatType type)
    {
        return runtimeStats.TryGetValue(type, out var value) ? value : 0f;
    }

    public void SetStat(StatType type, float value)
    {
        runtimeStats[type] = value;
        OnPlayerStatUpdated?.Invoke();
    }

    public void ModifyStatMultiplicative(StatType type, float delta)
    {
        Debug.Log(type);
        runtimeStats[type] *= delta;
        OnPlayerStatUpdated?.Invoke();
    }

    public void ModifyStatAdditive(StatType type, float delta)
    {
        runtimeStats[type] += delta;
        OnPlayerStatUpdated?.Invoke();
    }


}
