using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class affichageScoreFinal : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        tmp.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (finalsScore.isFinished)
        {
            tmp.SetText("+" + finalsScore.timeAdded + "s");
        }
    }
}
