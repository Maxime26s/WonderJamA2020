using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Superposes : MonoBehaviour
{
    public GHController ghc;
    private bool wrong;
    Input input;
    bool a, b, x, y;
    private void Awake()
    {
        input = InputManager.Instance.input;
    }

    private void Update()
    {
        bool a = input.Game.A.triggered, b = input.Game.B.triggered, x = input.Game.X.triggered, y = input.Game.Y.triggered;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (true)
        {
            a = input.Game.A.triggered;
            if (a)
                Debug.Log("stay" + Time.frameCount + other.name);
            //bool a = input.Game.A.triggered, b = input.Game.B.triggered, x = input.Game.X.triggered, y = input.Game.Y.triggered;
            Debug.Log(a.ToString() + b.ToString() + x.ToString() + y.ToString());
            if (a || b || x || y )
            {
                if (a && other.name == "A" || b && other.name == "B" || x && other.name == "X" || y && other.name == "Y")
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
                else
                {
                    if (ghc.comboMax < ghc.combo)
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
