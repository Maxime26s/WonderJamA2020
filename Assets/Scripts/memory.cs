using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class memory : MonoBehaviour
{

    public Image button_affiche;
    public Image good;
    public Sprite bien;
    public Sprite mauvais;

    public Sprite abut;
    public Sprite bbut;
    public Sprite xbut;
    public Sprite ybut;
    public Sprite invisible;

    int button_to_be_pressed;
    int progress = 0;
    bool stop = true;

    List<Sprite> sprites = new List<Sprite>();
    List<int> secance = new List<int>();
    public List<Image> images = new List<Image>();

    float startSeconds;

    bool show1 = true;
    bool reussi = false;
    bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        button_affiche.sprite = invisible;
        for(int i = 0; i < images.Count; i++)
        {
            images[i].sprite = invisible;
        }
        startSeconds = GameManager.Instance.mapManager.timer.minutes * 60 + GameManager.Instance.mapManager.timer.seconds;
        sprites.Add(abut);
        sprites.Add(bbut);
        sprites.Add(xbut);
        sprites.Add(ybut);
        sprites.Add(invisible);

        for (int i = 0; i<5; i++)
        {
            secance.Add(r());
        }
        StartCoroutine(showsec(5));
        show1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (!Input.GetButton("A")
            && !Input.GetButton("B")
            && !Input.GetButton("X")
            && !Input.GetButton("Y"))
            {
                buttonPressed = false;
            }
            if (startSeconds  - 30 >= GameManager.Instance.mapManager.timer.minutes * 60 + GameManager.Instance.mapManager.timer.seconds )
            {
                stop = true;
                GameManager.Instance.LoadMap();
            }
            if (!reussi)
            {
                button_to_be_pressed = secance[progress];
            }

            if (!buttonPressed)
            {
                if (Input.GetButton("A"))
                {
                    buttonPressed = true;
                    if (0 == button_to_be_pressed)
                    {
                        progress++;
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        images[progress].sprite = mauvais;
                        progress = 0;
                        StartCoroutine(showWrong());
                    }
                }
                if (Input.GetButton("B"))
                {
                    buttonPressed = true;
                    if (1 == button_to_be_pressed)
                    {
                        progress++;
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        images[progress].sprite = mauvais;
                        progress = 0;
                        StartCoroutine(showWrong());
                    }
                }
                if (Input.GetButton("X"))
                {
                    buttonPressed = true;
                    if (2 == button_to_be_pressed)
                    {
                        progress++;
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        images[progress].sprite = mauvais;
                        progress = 0;
                        StartCoroutine(showWrong());
                    }
                }
                if (Input.GetButton("Y"))
                {
                    buttonPressed = true;
                    if (3 == button_to_be_pressed)
                    {
                        progress++;
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        images[progress].sprite = mauvais;
                        progress = 0;
                        StartCoroutine(showWrong());
                    }
                }
            }

            Debug.Log(progress);
            
            if(progress >= 5)
            {
                reussi = true;
                good.sprite = bien;
                //mot.text = "Bravo!!!";
                IEnumerator WaitASec()
                {
                    yield return new WaitForSeconds(0.5f);
                    GameManager.Instance.LoadMap();
                }
                StartCoroutine(WaitASec());
            }
        }

    }

    int r()
    {
        return Random.Range(0, 4);
    }
    IEnumerator showsec(int nb)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < nb; i++)
        {
            button_affiche.sprite = sprites[secance[i]];
            yield return new WaitForSeconds(1);
            button_affiche.sprite = sprites[4];
            yield return new WaitForSeconds(0.25f);
        }
        stop = false;
    }
    IEnumerator showWrong()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].sprite = invisible;
        }

    }
    IEnumerator showGood()
    {
        images[progress-1].sprite = bien;
        yield return null;
    }
}
