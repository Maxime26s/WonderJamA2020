﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float minutes = 5;
    public float seconds = 0;
    public float miliseconds = 0;
    public bool running = false;
    public bool player;
    //public GameObject textDamage, canv;
    
    private void Start()
    {
        if(timer == null)
            timer = GetComponentInChildren<TextMeshProUGUI>();
        //textDamage = canv.transform.Find("TakingDamageText").gameObject;
    }

    void Update()
    {
        if (running)
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
            DeathCheck();
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

    public void AddTime(float secondes)
    {
        if(secondes + seconds > 59)
        {
            minutes++;
            secondes -= 60 - seconds;
            seconds = 0;
            seconds += secondes;
        }
        else
        {
            seconds += secondes;
        }
        DeathCheck();
    }

    public void RemoveTime(float secondes)
    {
        if (secondes > seconds)
        {
            minutes--;
            secondes -= seconds;
            seconds = 59;
            seconds -= secondes;
        }
        else
        {
            seconds -= secondes;
        }
        DeathCheck();
    }

    public void RemoveTime(float secondes, float millisecondes)
    {
        if (millisecondes >= miliseconds)
        {
            seconds--;
            millisecondes -= miliseconds;
            miliseconds = 100;
            miliseconds -= millisecondes;
        }
        else
        {
            miliseconds -= millisecondes;
        }

        if (secondes >= seconds)
        {
            minutes--;
            secondes -= seconds;
            seconds = 59;
            seconds -= secondes;
        }
        else
        {
            seconds -= secondes;
        }
        DeathCheck();
    }

    IEnumerator TakingDamage(GameObject go)
    {
        Debug.Log(go);
        go.GetComponent<TextMeshProUGUI>().fontSize = 36f;
        Color32 col = go.GetComponent<TextMeshProUGUI>().color;
        for (int i=0; i<100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            go.GetComponent<TextMeshProUGUI>().fontSize += 0.5f;
            col.a -= 2;
            go.GetComponent<TextMeshProUGUI>().color = col;
        }
        
        Destroy(go);
    }

    void DeathCheck()
    {
        if (minutes < 0)
        {
            minutes = 0;
            seconds = 0;
            miliseconds = 0;
            running = false;
            if (player)
                GameManager.Instance.LoadDeath();
        }
        RefreshText();
    }
}
