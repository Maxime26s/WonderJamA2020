﻿using System;
using UnityEngine;

public class colliderImages : MonoBehaviour
{
    public int speed;
    public bool actif;
    public int nbTouches;
    

    void Update()
    {
        if (actif)
        {
            transform.Translate(new Vector3(Convert.ToSingle(-0.0005 * speed), 0, 0));
        }

        if (finalsScore.compteurPassages == nbTouches)
        {
            finalsScore.timeAdded = (2 * Convert.ToSingle(finalsScore.compteur) / Convert.ToSingle(nbTouches))*Convert.ToSingle(finalsScore.compteur);
            Debug.Log(finalsScore.compteur);
            Debug.Log(nbTouches);
            Debug.Log(finalsScore.timeAdded);
            finalsScore.compteurPassages = 0;
            finalsScore.isFinished = true;
        }
        
    }
}