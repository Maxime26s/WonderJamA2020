using System;
using UnityEngine;

public class colliderImages : MonoBehaviour
{
    public int speed;
    public bool actif;
    public int nbTouches;
    public int multiplicateurMax;
    public double secParTouche;
    

    void Update()
    {
        if (actif)
        {
            transform.Translate(new Vector3(Convert.ToSingle(-0.0005 * speed), 0, 0));
        }

        if (finalsScore.compteurPassages == nbTouches)
        {
            finalsScore.timeAdded = (multiplicateurMax * Convert.ToSingle(finalsScore.compteur) / Convert.ToSingle(nbTouches)) * secParTouche * Convert.ToSingle(finalsScore.compteur);
            finalsScore.compteurPassages = 0;
            finalsScore.isFinished = true;
        }
        
    }
}
