using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public PlayerCharacter player;
    public float totalTime;
    public Text timerText; 

    private float timeLeft;

    private void Start()
    {
        timeLeft = totalTime;
    }

    private void Update()
    {
        timerText.text = timeLeft.ToString("000");
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            player.GameOver();
        }
    }
}
