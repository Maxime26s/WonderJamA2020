using System;
using UnityEngine;

public class colliderImages : MonoBehaviour
{
    public double speed;
    public bool actif;
    public double nbTouches;
    public double multiplicateurMax;
    public double secParTouche;
    public double BPM;

    void Update()
    {
        if (actif)
        {
            transform.Translate(new Vector3((float) (-speed * Time.deltaTime), 0, 0));//Convert.ToSingle(-0.000532 * speed * (BPM/180.0)), 0, 0));
        }
        /*
        if (finalsScore.compteurPassages == nbTouches)
        {
            Debug.Log(finalsScore.compteur);
            Debug.Log(finalsScore.compteurPassages);
            Debug.Log(nbTouches);

            finalsScore.timeAdded = (multiplicateurMax * Convert.ToSingle(finalsScore.compteur) / nbTouches) * secParTouche * Convert.ToSingle(finalsScore.compteur);
            finalsScore.compteurPassages = 0;
            finalsScore.isFinished = true;
            
        }
        */
    }
}
