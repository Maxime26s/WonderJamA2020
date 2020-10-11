using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class controlTrack : MonoBehaviour
{

    public GameObject trackGH1;
    public GameObject trackGH2;
    public GameObject trackGH3;
    
    public GameObject audioGH1;
    public GameObject audioGH2;
    public GameObject audioGH3;

    public int selectorBase;
    
    // Start is called before the first frame update
    void Start()
    {
        if (selectorBase <= 0 || selectorBase>3)
        {
            Random rand = new Random();
                    selectorBase = rand.Next(1, 4);
        }
        
        switch (selectorBase)
        {
            case 1:
                trackGH1.SetActive(true);
                trackGH2.SetActive(false);
                trackGH3.SetActive(false);
                audioGH1.SetActive(true);
                audioGH2.SetActive(false);
                audioGH3.SetActive(false);
                break;
            case 2:
                trackGH1.SetActive(false);
                trackGH2.SetActive(true);
                trackGH3.SetActive(false);
                audioGH1.SetActive(false);
                audioGH2.SetActive(true);
                audioGH3.SetActive(false);
                break;
            case 3:
                trackGH1.SetActive(false);
                trackGH2.SetActive(false);
                trackGH3.SetActive(true);
                audioGH1.SetActive(false);
                audioGH2.SetActive(false);
                audioGH3.SetActive(true);
                break;
        }
        {
            
        }


    }
}
