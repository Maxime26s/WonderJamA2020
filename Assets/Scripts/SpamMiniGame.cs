using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SpamMiniGame : MonoBehaviour
{
    private int n = 0;
    public TextMeshProUGUI text;
    public SpriteRenderer image;
    public Sprite imageA;
    public Sprite imageAPushed;
    private bool waiting=false;
    public bool ok = false;
    private void Start()
    {
        n = Random.Range(20, 45);
        text.text = "Appuyez " + n + " fois sur le boutton A pour ouvrir le coffre.";
       
    }
    public void Update()
    {
        
         if (Input.GetButtonDown("A"))
        {
            image.sprite = imageAPushed;
            if (n > 0)
            {   
                n--;
                text.text = "Appuyez " + n + " fois sur le boutton A pour ouvrir le coffre.";
            }
        }
        if (Input.GetButtonUp("A"))
        {
            image.sprite = imageA;
        }
        if (n == 0)
        {
            //chest open
            text.text = "GG";
            StartCoroutine(WaitAndPrint());
            if (ok)
            {
                Application.LoadLevel(2);
            }
        }
    }
    private IEnumerator WaitAndPrint()
    {
        Color r = image.GetComponent<SpriteRenderer>().color;
        r.a = 0f;
        image.GetComponent<SpriteRenderer>().color = r;
        yield return new WaitForSeconds(5f);
        ok = true;

    }

}
