using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


  
    public float fireRateMultiplier = 1f;
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
    public int level = 0;
    public event Action OnPlayerStatUpdated;

    public WorldState worldState;
    public void Start()
    {
        worldState.tilemapData.OnTileBroke += AddXp;
    }

    public void AddXp(Vector3Int pos)
    {
        xp++;
    }

    public void Update()
    {
      
        if (xp >= xpRequired)
        {
            xp -= xpRequired;
            level++;
        }
    }


}
