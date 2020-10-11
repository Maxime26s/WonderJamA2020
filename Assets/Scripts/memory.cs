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
    public TextMeshProUGUI mot;

    public Sprite abut;
    public Sprite bbut;
    public Sprite xbut;
    public Sprite ybut;
    public Sprite invisible;

    int button_to_be_pressed;
    int progress = 0;
    bool stop = false;

    List<Sprite> sprites = new List<Sprite>();
    List<int> secance = new List<int>();

    float startSeconds;

    bool show1 = true;
    bool reussi = false;
    
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (startSeconds  - 30 >= GameManager.Instance.mapManager.timer.minutes * 60 + GameManager.Instance.mapManager.timer.seconds )
            {
                stop = true;
                GameManager.Instance.LoadMap();
            }
            if (!reussi)
            {
                button_to_be_pressed = secance[progress];
            }
        
            if (show1)
            {
                StartCoroutine(showsec(5));
                show1 = false;
            }

            if (Input.GetButtonDown("A"))
            {
                if(0 == button_to_be_pressed)
                {
                    progress++;
                    StartCoroutine(showGood());
                }
                else
                {
                    progress = 0;
                    StartCoroutine(showWrong());
                }
            }
            if (Input.GetButtonDown("B"))
            {
                if (1 == button_to_be_pressed)
                {
                    progress++;
                    StartCoroutine(showGood());
                }
                else
                {
                    progress = 0;
                    StartCoroutine(showWrong());
                }
            }
            if (Input.GetButtonDown("X"))
            {
                if (2 == button_to_be_pressed)
                {
                    progress++;
                    StartCoroutine(showGood());
                }
                else
                {
                    progress = 0;
                    StartCoroutine(showWrong());
                }
            }
            if (Input.GetButtonDown("Y"))
            {
                if (3 == button_to_be_pressed)
                {
                    progress++;
                    StartCoroutine(showGood());
                }
                else
                {
                    progress=0;
                    StartCoroutine(showWrong());
                }
            }
            if(progress == 5)
            {
                reussi = true;
                good.sprite = bien;
                mot.text = "Bravo!!!";
                IEnumerator WaitASec()
                {
                    yield return new WaitForSeconds(1.5f);
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
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < nb; i++)
        {
            button_affiche.sprite = sprites[secance[i]];
            yield return new WaitForSeconds(1);
            button_affiche.sprite = sprites[4];
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    IEnumerator showWrong()
    {
        good.sprite = mauvais;
        mot.text = "Oupss! Essaie encore!";
        yield return new WaitForSeconds(0.4f);
        good.sprite = invisible;
        mot.text = "";

    }
    IEnumerator showGood()
    {
        good.sprite = bien;
        mot.text = "Oui!";
        yield return new WaitForSeconds(0.4f);
        good.sprite = invisible;
        mot.text = "";

    }
}
