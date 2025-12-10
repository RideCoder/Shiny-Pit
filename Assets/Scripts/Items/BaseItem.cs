using UnityEngine;

public class BaseItem : MonoBehaviour
{

    public virtual void AddToPlayer(PlayerState playerState)
    {
        Debug.Log("ADDED TO PLAYER");
    }
}
