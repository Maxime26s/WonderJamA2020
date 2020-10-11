using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                    if (ghc.comboMax < ghc.combo)
                        ghc.comboMax = ghc.combo;
                    Instantiate(ghc.particles, other.gameObject.transform.position, Quaternion.identity);
                    ghc.comboText.GetComponent<TextMeshProUGUI>().text = string.Format("Combo: {0:#0}", ghc.combo);
                    ghc.comboMaxText.GetComponent<TextMeshProUGUI>().text = string.Format("Max Combo: {0:#0}", ghc.comboMax);
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
