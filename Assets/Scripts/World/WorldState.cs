using UnityEngine;

public class WorldState : MonoBehaviour {

    public PlayerState playerState;
    public PlayerStats playerStats;
    public PlayerController2D playerController;
    public TilemapData tilemapData;


    public static float worldTime = 1200f;

    public void Update()
    {
        worldTime -= Time.deltaTime;
    }



}