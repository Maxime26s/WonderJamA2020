using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

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
            images[i].color = new Color32(255, 255, 255, 0);
            images[i].sprite = bien;
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
            InputSystem.Update();
            if (!InputManager.Instance.a
            && !InputManager.Instance.b
            && !InputManager.Instance.x
            && !InputManager.Instance.y)
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
                if (InputManager.Instance.a)
                {
                    buttonPressed = true;
                    if (0 == button_to_be_pressed)
                    {
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        StartCoroutine(showWrong());
                    }
                }
                if (InputManager.Instance.b)
                {
                    buttonPressed = true;
                    if (1 == button_to_be_pressed)
                    {
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        StartCoroutine(showWrong());
                    }
                }
                if (InputManager.Instance.x)
                {
                    buttonPressed = true;
                    if (2 == button_to_be_pressed)
                    {
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        StartCoroutine(showWrong());
                    }
                }
                if (InputManager.Instance.y)
                {
                    buttonPressed = true;
                    if (3 == button_to_be_pressed)
                    {
                        StartCoroutine(showGood());
                    }
                    else
                    {
                        StartCoroutine(showWrong());
                    }
                }
            }
            
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
        yield return new WaitForSeconds(1f);
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
        images[progress].sprite = mauvais;
        images[progress].color = new Color32(255, 255, 255, 255);
        progress = 0;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color32(255, 255, 255, 0);
            images[i].sprite = bien;
        }

    }
    IEnumerator showGood()
    {
        progress++;
        images[progress - 1].sprite = bien;
        images[progress - 1].color = new Color32(255, 255, 255, 255);
        yield return null;
    }
}
