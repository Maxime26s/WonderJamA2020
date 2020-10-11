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
            if(minutes < 0)
            {
                minutes = 0;
                seconds = 0;
                miliseconds = 0;
                running = false;
                GameManager.Instance.LoadDeath();
            }
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
            seconds -= secondes;
        }
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
    }

    public void LoseTime(float damage)
    {
        seconds -= damage;
        //GameObject txt = Instantiate(textDamage, new Vector2(transform.position.x + Random.Range(-100f, 100f), transform.position.y + Random.Range(-100f, 100f)), Quaternion.identity);
        //txt.transform.SetParent(timer.transform, false);
        //txt.GetComponent<TextMeshProUGUI>().text = "-" + (float)Mathf.Round(damage * 100f) / 100f;
        //StartCoroutine(TakingDamage(txt));
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
}
