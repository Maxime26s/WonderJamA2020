using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float minutes = 5;
    public float seconds = 0;
    public float miliseconds = 0;

    void Update()
    {
        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;

        if(minutes>0)
            timer.text = string.Format("{0}:{1}", minutes, seconds);
        else
            timer.text = string.Format("{0}:{1}", seconds, (int)miliseconds);
    }
}
