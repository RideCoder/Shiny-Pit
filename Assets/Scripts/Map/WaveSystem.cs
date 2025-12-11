using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

[Serializable]
public class Wave
{
   public float startTime;
   public float endTime;
   public float spawnTime;
    public float time;
   public Enemy enemy;

    

}
[Serializable]
public class WaveGroup
{
   public  List<Wave> waves;
}

public class WaveSystem : MonoBehaviour {

    public List<WaveGroup> waveGroups;
    public GameObject player;
    public float time = 0;
    public static event Action<Vector3, Enemy> OnSpawnEnemy;
    public void Start()
    {
        
    }

    public void Update()
    {
        //Maybe an item that increase how fast time goes or slows down time?
        time += Time.deltaTime;

        foreach (var waveGroup in waveGroups)
        {
            foreach (var wave in waveGroup.waves)
            {
                if (time >= wave.startTime && wave.endTime >= time)
                {
                    Debug.Log("Test");
                    wave.time += Time.deltaTime;
                    if (wave.time >= wave.spawnTime)
                    {
                        wave.time = 0;
                        OnSpawnEnemy?.Invoke(player.transform.position,wave.enemy);
                    }
                }
            }
        }

    }


}