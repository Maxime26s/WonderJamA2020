using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SpamMiniGame : MonoBehaviour
{
    public int n = 0;
    public TextMeshProUGUI text;
    private void Start()
    {
         n = Random.Range(20, 45);
        text.text = "Appuyez " + n + " fois sur le boutton A pour ouvrir le coffre."; 
    }
    public void Update()
    {
         if (Input.GetButtonDown("ButtonA"))
        {
            if (n > 0)
            {
                n--;
                text.text = "Appuyez " + n + " fois sur le boutton A pour ouvrir le coffre.";
            }   
        }
        if (n == 0)
        {
            //chest open
            text.text = "GG";
        }
    }
}
