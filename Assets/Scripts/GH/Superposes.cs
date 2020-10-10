using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superposes : MonoBehaviour
{
    private bool trigg = false;
    private bool wrong;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!wrong)
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
                    wrong = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
         {
             finalsScore.compteurPassages++;
             wrong = false;
         }
}
