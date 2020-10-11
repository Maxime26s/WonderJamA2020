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
    public SpriteRenderer coffre;
    private bool waiting=false;
    public bool ok = false;
    public int x = 1;
    public int a;
    public bool ok1 = true;
    private void Start()
    {
        n = Random.Range(20, 45);
        a = n;
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
                coffre.transform.Rotate(0, 0, 20*x);
                coffre.transform.Translate(.2f*x, 0, 0);
            }
        }
        if (Input.GetButtonUp("A"))
        {
            x = -x;
            image.sprite = imageA;
        }
        if (n == 0)
        {
            //chest open
            coffre.transform.position = Vector2.zero;
            if(a%2 != 0 && ok1)
            {
                ok1 = false;
                coffre.transform.Rotate(0, 0, -20);
            }
            text.text = "Félicitations, vous avez gagné " + (a/2)+ " secondes";
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
