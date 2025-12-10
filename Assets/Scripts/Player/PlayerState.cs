using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class PlayerState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Health health;
    public List<BaseItem> items;
  
    public void Start()
    {
       
    }

   


}
