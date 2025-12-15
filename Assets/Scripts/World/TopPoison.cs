using UnityEngine;

public class TopPoison : MonoBehaviour
{
    public Transform player;

    [Header("Movement Settings")]
    private float startY = 800f;
    private float endY = 0f;
    private float duration = WorldState.worldTime; // seconds to go from 500 to 0

    private float elapsedTime = 0f;

    void Start()
    {
        // Initialize starting position
        transform.position = new Vector3(
            player.position.x,
            startY,
            transform.position.z
        );
    }

    void Update()
    {
        // Track time
        elapsedTime += Time.deltaTime;

        // Calculate interpolation factor (0 → 1 over duration)
        float t = Mathf.Clamp01(elapsedTime / duration);

        // Lerp Y position
        float currentY = Mathf.Lerp(startY, endY, t);

        // Apply position: X follows player, Y from lerp
        transform.position = new Vector3(
            player.position.x,
            currentY,
            transform.position.z
        );
    }
}
