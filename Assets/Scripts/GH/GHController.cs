using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GHController : MonoBehaviour
{
    public float hit = 0, combo = 0, comboMax = 0, total;
    public GameObject result, guide, particles, comboText, comboMaxText;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        total = 40;
        IEnumerator Manager()
        {
            yield return new WaitForSeconds(24f);
            int resultat = (int)(comboMax / total * hit * 1.5f);
            if (resultat < 15)
                resultat = 15;
            GameManager.Instance.AjoutTemps(resultat);
            IEnumerator Reset()
            {
                animator.SetBool("End", true);
                yield return new WaitForSeconds(0.15f);
                animator.SetBool("End", false);
                yield return new WaitForSeconds(0.8f);
            }
            StartCoroutine(Reset());
            TextMeshProUGUI text = result.GetComponentInChildren<TextMeshProUGUI>();
            if (resultat < total/2)
                text.color = new Color32(255, 54, 74, 255);
            else
                text.color = new Color32(79, 240, 122, 255);
            text.text = string.Format("+{0:##} seconds", resultat);
            yield return new WaitForSeconds(2f);
            GameManager.Instance.LoadMap();
            MusicManager.Instance.MapMusic();
        }
        StartCoroutine(Manager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
