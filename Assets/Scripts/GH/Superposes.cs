using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superposes : MonoBehaviour
{
    private bool trigg = false;


    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.anyKey)
        {
            if (Input.GetButton(other.name))
            {
                finalsScore.compteur++;
                     Destroy(other.gameObject);
            }
                 else if (!Input.GetButton(other.name))
                 {
                     
                     
                     Debug.Log("NO");
                 }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
         {
             Debug.Log("Passage");
             finalsScore.compteurPassages++;
         }
}
