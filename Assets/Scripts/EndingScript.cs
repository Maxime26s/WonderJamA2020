using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public int nbOfStars = 10;
    public int nbOfExplosions = 10;
    public float textSpeed = 10f;
    public float moveSpeed = 1f;
    public float blackSpeed = 1f;
    public float bgSpeed = 1f;
    public float cubeSpeed = 1f;
    public GameObject star, blueBG, redBG;
    public GameObject rolex, bigRolex, smallRolex;
    public GameObject xelor, bigXelor, smallXelor;
    public GameObject topBlack, botBlack;
    public GameObject dacube, explosion, text, fade, end;
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

        StartCoroutine("EndStory");
    }

    IEnumerator EndStory()
    {
        yield return StartCoroutine("MoveCharacters");
        yield return StartCoroutine("CinematicMode");
        yield return StartCoroutine("AwkwardStare");
        yield return StartCoroutine("RollCredits");
    }

    IEnumerator MoveCharacters()
    {
        bool flipped = false;
        for(float i = rolex.transform.position.x; i <= 4f; i += moveSpeed * Time.deltaTime) 
        {
            if(rolex.transform.position.x > xelor.transform.position.x && !flipped)
            {
                flipped = true;
                rolex.GetComponent<SpriteRenderer>().flipX = true;
                xelor.GetComponent<SpriteRenderer>().flipX = true;
            }

            rolex.transform.position = new Vector3(i, rolex.transform.position.y, 0);
            xelor.transform.position = new Vector3(-i, xelor.transform.position.y, 0);
            yield return null;
        }

        yield return null;
    }

    IEnumerator CinematicMode()
    {
        rolex.GetComponent<SpriteRenderer>().enabled = false;
        xelor.GetComponent<SpriteRenderer>().enabled = false;
        bigRolex.GetComponent<SpriteRenderer>().enabled = true;

        blueBG.SetActive(true);

        StartCoroutine("MoveBlue");

        for(float i = topBlack.transform.position.y; i >= 5f; i -= blackSpeed * Time.deltaTime) 
        {
            topBlack.transform.position = new Vector3(0, i, 0);
            botBlack.transform.position = new Vector3(0, -i, 0);
            yield return null;
        }

        bigRolex.GetComponent<SpriteRenderer>().enabled = false;
        bigXelor.GetComponent<SpriteRenderer>().enabled = true;

        yield return StartCoroutine("MoveRed");

        bigXelor.GetComponent<SpriteRenderer>().enabled = false;

        yield return null;
    }

    IEnumerator MoveBlue()
    {
        for(float i = blueBG.transform.position.x; i <= 0f; i += bgSpeed * Time.deltaTime) 
        {
            blueBG.transform.position = new Vector3(i, 0, 0);
            yield return null;
        }
    }

    IEnumerator MoveRed()
    {
        blueBG.SetActive(false);
        redBG.SetActive(true);
        for(float i = redBG.transform.position.x; i >= -20f; i -= bgSpeed * Time.deltaTime) 
        {
            redBG.transform.position = new Vector3(i, 0, 0);
            yield return null;
        }
        redBG.SetActive(false);

        yield return null;
    }

    IEnumerator AwkwardStare()
    {
        topBlack.GetComponent<SpriteRenderer>().enabled = false;
        botBlack.GetComponent<SpriteRenderer>().enabled = false;
        smallRolex.GetComponent<SpriteRenderer>().enabled = true;
        smallXelor.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(2);

        smallRolex.GetComponent<ParticleSystem>().Play();
        this.GetComponent<AudioSource>().clip = sounds[2];
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3);

        smallRolex.GetComponent<ParticleSystem>().Stop();

        this.GetComponent<AudioSource>().clip = sounds[1];
        this.GetComponent<AudioSource>().Play();
        dacube.SetActive(true);

        yield return StartCoroutine("MoveDaCube");
        
        yield return null;
    }

    IEnumerator MoveDaCube()
    {
        for(float i = dacube.transform.position.x; i >= -6f; i -= cubeSpeed * Time.deltaTime) 
        {
            dacube.transform.position = new Vector3(i, 0, 0);
            yield return null;
        }

        dacube.SetActive(false);

        yield return new WaitForSeconds(2);

        StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        smallXelor.SetActive(false);
        this.GetComponent<AudioSource>().clip = sounds[0];
        for(int i = 0; i < nbOfExplosions; i++)
        {
            GameObject newExplosion = Instantiate(explosion, new Vector3(Random.Range(smallXelor.transform.position.x - 0.5f, smallXelor.transform.position.x + 0.5f), Random.Range(smallXelor.transform.position.y - 0.5f, smallXelor.transform.position.y + 0.5f), 0), Quaternion.identity);
            
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.5f);
            newExplosion.SetActive(false);
        }
        
        yield return null;
    }

    IEnumerator RollCredits()
    {
        for(float i = -400; i <= 2200f; i += textSpeed * Time.deltaTime) 
        {
            text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            yield return null;
        }

        yield return StartCoroutine("FadeOut");
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
        
        end.SetActive(true);
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
