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
    public float seconds = 7;
    public float miliseconds = 0;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI points;
    public TextMeshProUGUI text;
    public bool ok = false;
    public bool good = false;
    void Start()
    {
        points.text = "0";
        n = 0;
        StartCoroutine(WaitAndPrint());
    }

    // Update is called once per frame
    void Update()
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

            if (Input.GetButtonDown("ButtonA"))
            {
                sprite.sprite = buttonA;
                n++;
                points.text = "" + n;
            }
            if (Input.GetButtonUp("ButtonA"))
            {
                sprite.sprite = buttonAPushed;
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
        ok = true;
        if (good)
        {
          Application.LoadLevel(0);
        } 
    }
}
