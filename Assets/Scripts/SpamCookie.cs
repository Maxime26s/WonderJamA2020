using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpamCookie : MonoBehaviour
{
    private int n;
    public SpriteRenderer sprite;
    public Sprite buttonA;
    public Sprite buttonAPushed;
    public SpriteRenderer Go;
    public float seconds = 7;
    public float miliseconds = 0;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI points;
    public TextMeshProUGUI text;
    public bool ok = false;
    public bool good = false;
    private bool ok1 = false;
    void Awake()
    {
        Color r = Go.GetComponent<SpriteRenderer>().color;
        r.a = 0;
        Go.GetComponent<SpriteRenderer>().color = r;
        points.text = "0";
        n = 0;
        StartCoroutine(WaitAndPrint());
    }
    
        

    // Update is called once per frame
    public void Update()
    {
        if (ok)
        {
            if (miliseconds <= 0)
            {
                seconds--;
                miliseconds = 100;
            }

            miliseconds -= Time.deltaTime * 100;
            timer.text = string.Format("{0}:{1}", seconds, (int)miliseconds);

            if (Input.GetButtonDown("A"))
            {
                sprite.sprite = buttonAPushed;
                n++;
                points.text = "" + n;
                if (!ok1)
                {
                    for(int i = 0; i < 20; i++)
                    {
                        StartCoroutine("FadeOut");
                    }
                    
                }

            }
            if (Input.GetButtonUp("A"))
            {
                sprite.sprite = buttonA;
            }
            if (seconds <= 0 && miliseconds <= 0)
            {
                ok = false;
                good = true;
                text.text = "Félicitations vous avez gagné " + n + " secondes";
                StartCoroutine(WaitAndPrint());           
            }
        }
    }
    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(5f);
        if (!ok1)
        {
            for(int i = 0; i < 20; i++)
            {
                 StartCoroutine("FadeIn");
            }
       
        }      
        ok = true;
        if (good)
        {
          Application.LoadLevel(2);
        } 
    }
    IEnumerator FadeIn()
    {
        
        for (float f = 0.00f; f < 1; f += 1 * Time.deltaTime)
        {
            Color r = Go.GetComponent<SpriteRenderer>().color;
            r.a = f;
            Go.GetComponent<SpriteRenderer>().color = r;
            yield return new WaitForSeconds(0.0001f);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0; f -= 1 * Time.deltaTime)
        {
            Color r = Go.GetComponent<SpriteRenderer>().color;
            r.a = f;
            Go.GetComponent<SpriteRenderer>().color = r;
            if (f < 0.05f)
            {
                f = 0;
                r.a = f;
                Go.GetComponent<SpriteRenderer>().color = r;
            }
            ok1 = true;
            Debug.Log(f);
            yield return new WaitForSeconds(0.0001f);
        }
    }
}
