using UnityEngine;

public class WorldState : MonoBehaviour {

    public PlayerState playerState;
    public PlayerStats playerStats;
    public PlayerController2D playerController;
    public TilemapData tilemapData;


    public static float worldTime = 600f;

    public void Update()
    {
        worldTime -= Time.deltaTime;
    }



}