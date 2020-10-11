using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superposes : MonoBehaviour
{
    public GHController ghc;
    private bool wrong;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!wrong)
        {
            if (Input.anyKey)
            {
                if (Input.GetButton(other.name))
                {
                    ghc.hit++;
                    ghc.combo++;
                    //finalsScore.compteur++;
                    Destroy(other.gameObject);
                }
                else if (!Input.GetButton(other.name))
                {
                    if(ghc.comboMax < ghc.combo)
                        ghc.comboMax = ghc.combo;
                    ghc.combo = 0;
                    wrong = true;

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
         {
             //finalsScore.compteurPassages++;
             wrong = false;
         }
}
