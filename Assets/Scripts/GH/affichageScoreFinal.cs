using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class affichageScoreFinal : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public GameObject bouton;
    public GameObject outline;

    private void Start()
    {
        bouton.SetActive(false);
        outline.SetActive(false);
        tmp.SetText("");
    }


    void Update()
    {
        if (finalsScore.isFinished)
        {
            tmp.SetText("+" + finalsScore.timeAdded + "s");
            bouton.SetActive(true);
            outline.SetActive(true);
        }
    }
}
