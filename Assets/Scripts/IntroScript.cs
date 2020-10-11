using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public int nbOfStars = 10;
    public float fadeSpeed = 0.1f;
    public float shakeDuration = 3;
    public float redDuration = 10;
    public float textSpeed = 1;
    public GameObject star;
    public GameObject fade;
    public GameObject earth;
    public GameObject text;
    public GameObject xelor;
    public GameObject rolex;
    public GameObject nuke;
    public List<GameObject> eyes;
    public List<AudioClip> sounds;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        for(int i = 0; i < nbOfStars; i++)
        {
            GameObject newStar = Instantiate(star, new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), 0), Quaternion.identity);
            newStar.GetComponent<Animator>().Play("Star Twinkle", 0, Random.Range(0.0f, 1.0f));
        }

        StartCoroutine("Intro");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Intro()
    {
        StartCoroutine("MoveText");
        StartCoroutine("ShowProps");
        yield return StartCoroutine("FadeIn");
        yield return StartCoroutine("ApproachEarth");
        yield return StartCoroutine("EarthShake");
        yield return StartCoroutine("EarthRed");
    }

    IEnumerator ShowProps() 
    {
        yield return new WaitForSeconds(12);
        for(float i = 0; i <= 0.1f; i += 0.1f * Time.deltaTime) 
        {
            Color c = xelor.GetComponent<SpriteRenderer>().color;
            c.a = i;
            xelor.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        for(float i = 0; i <= 0.1f; i += 0.1f * Time.deltaTime) 
        {
            Color c = nuke.GetComponent<SpriteRenderer>().color;
            c.a = i;
            nuke.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        for(float i = 0.1f; i > 0; i -= 0.1f * Time.deltaTime) 
        {
            Color c = xelor.GetComponent<SpriteRenderer>().color;
            c.a = i;
            xelor.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        for(float i = 0.1f; i > 0; i -= 0.1f * Time.deltaTime) 
        {
            Color c = nuke.GetComponent<SpriteRenderer>().color;
            c.a = i;
            nuke.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        for(float i = 0; i <= 0.1f; i += 0.1f * Time.deltaTime) 
        {
            Color c = rolex.GetComponent<SpriteRenderer>().color;
            c.a = i;
            rolex.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        
        for(float i = earth.transform.position.y; i >= -3f; i -= 1f * Time.deltaTime) 
        {
            earth.transform.position = new Vector3(0, i, 0);
            yield return null;
        }

        for(float i = 0; i <= 100f; i += 1f * Time.deltaTime) 
        {
            foreach(GameObject eye in eyes)
            {
                eye.GetComponent<Light2D>().intensity = i;
            }
        }
    }

    IEnumerator MoveText() 
    {
        for(float i = -560f; i <= 3800f; i += textSpeed * Time.deltaTime) 
        {
            text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            yield return null;
        }
        SceneManager.LoadScene("Map");
    }

    IEnumerator FadeIn() 
    {
        for(float ft = 1f; ft >= 0; ft -= fadeSpeed * Time.deltaTime) 
        {
            Color c = fade.GetComponent<SpriteRenderer>().color;
            c.a = ft;
            fade.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut() 
    {
        for(float ft = 0f; ft <= 1f; ft += fadeSpeed * Time.deltaTime) 
        {
            Color c = fade.GetComponent<SpriteRenderer>().color;
            c.a = ft;
            fade.GetComponent<SpriteRenderer>().color = c;
        }
        Application.LoadLevel(2);
        yield return null;
    }

    IEnumerator ApproachEarth() 
    {
        for(float size = 1f; size <= 4f; size += 1 * Time.deltaTime) 
        {
            earth.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            yield return null;
        }
        yield return new WaitForSeconds(2);
    }

    public IEnumerator EarthShake()
    {
        this.GetComponent<AudioSource>().clip = sounds[0];
        this.GetComponent<AudioSource>().Play();
        Vector3 orignalPosition = earth.transform.position;
        float elapsed = 0f;
        
        while (elapsed < shakeDuration)
        {
            earth.transform.position = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        earth.transform.position = orignalPosition;
    }

    public IEnumerator EarthRed()
    {
        Vector3 orignalPosition = earth.transform.position;
        float elapsed = 0f;
        
        while(elapsed < redDuration)
        {
            earth.transform.position = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            elapsed += Time.deltaTime;

            Color c = earth.GetComponent<SpriteRenderer>().color;
            c.b = 1 - (elapsed / redDuration);
            c.g = 1 - (elapsed / redDuration);
            earth.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        earth.transform.position = orignalPosition;
        this.GetComponent<AudioSource>().Stop();
    }
}
