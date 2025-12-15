using TMPro;
using UnityEngine;

public class PlayerDepth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TMP_Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float timeRemaining = WorldState.worldTime;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        text.text = $"Time Left: {minutes:0}:{seconds:00}";

    }
}
