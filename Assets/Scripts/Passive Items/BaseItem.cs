using UnityEngine;

public class BaseItem : MonoBehaviour
{
    
    public virtual void AddToPlayer(WorldState worldState)
    {
        Debug.Log("ADDED TO PLAYER");
    }
}
