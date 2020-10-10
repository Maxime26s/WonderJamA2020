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
    public bool enabled = false;

    void Update()
    {
        if (enabled)
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

            RefreshText();
        }
    }

    public void RefreshText()
    {
        if (minutes > 0)
            timer.text = string.Format("{0:#0}:{1:00}", minutes, seconds);
        else
        {
            if (seconds < 10)
                timer.color = new Color32(255, 54, 74, 255);
            else
                timer.color = new Color32(240, 139, 31, 255);
            timer.text = string.Format("{0:#0}:{1:00}", seconds, (int)miliseconds);
        }
    }
}
