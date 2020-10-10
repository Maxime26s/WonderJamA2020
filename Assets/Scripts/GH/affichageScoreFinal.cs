using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class affichageScoreFinal : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        tmp.SetText("");
    }

    void Update()
    {
        if (finalsScore.isFinished)
        {
            tmp.SetText("+" + finalsScore.timeAdded + "s");
        }
    }
}
