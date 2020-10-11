using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float textSpeed = 1f;
    public List<AudioClip> sounds;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateText("La terre n'est plus"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimateText(string strComplete)
    {
        string str = "";

        this.GetComponent<AudioSource>().clip = sounds[0];
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);

        this.GetComponent<AudioSource>().clip = sounds[1];

        for(int i = 0; i < strComplete.Length; i++)
        {
            str += strComplete[i];

            text.GetComponent<TextMeshProUGUI>().text = str;
            this.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        for(float ft = 0f; ft <= 1f; ft += 1 * Time.deltaTime) 
        {
            Color c = fade.GetComponent<SpriteRenderer>().color;
            c.a = ft;
            fade.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("Menu");
        yield return null;
    }

}
