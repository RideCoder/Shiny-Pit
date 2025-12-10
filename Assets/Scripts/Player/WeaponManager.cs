using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public List<PlayerWeapon> weapons = new List<PlayerWeapon>();

    public PlayerStats stats;
    public float baseFireRate;
    public float damageMultiplier;



}
