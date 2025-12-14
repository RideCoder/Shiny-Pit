using System;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Enemy enemy;
    private GameObject player;
    private TilemapData tilemap;
  
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void Initialize(GameObject player, TilemapData tilemap)
    {
        this.player = player;
        this.tilemap = tilemap;
    }

    
  

    public void Update()
    {
        if (player == null) return;
        if (player.transform.position.x > enemy.transform.position.x)
        {
            enemy.EnemyMovement.Move(new Vector2(1, 0));
            
        }
        else
        {
            enemy.EnemyMovement.Move(new Vector2(-1, 0));
        }


    }



}