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

    public event Action OnPlayerStatUpdated;
    public void Start()
    {
    
    }

    
}
