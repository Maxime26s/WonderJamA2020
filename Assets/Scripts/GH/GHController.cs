using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GHController : MonoBehaviour
{
    public int hit = 0, combo = 0, comboMax = 0, total;
    public GameObject result;
    // Start is called before the first frame update
    void Start()
    {
        total = 40;
        IEnumerator Manager()
        {
            yield return new WaitForSeconds(24f);
            int resultat = (int)(comboMax / total * hit);
            GameManager.Instance.AjoutTemps(resultat);
            result.SetActive(true); //change for a fade
            TextMeshProUGUI text = result.GetComponentInChildren<TextMeshProUGUI>();
            if (resultat < total/2)
                text.color = new Color32(255, 54, 74, 255);
            else
                text.color = new Color32(79, 240, 122, 255);
            text.text = string.Format("+{0:##} secondes", resultat);
            yield return new WaitForSeconds(2f);
            GameManager.Instance.LoadMap();
        }
        StartCoroutine(Manager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
