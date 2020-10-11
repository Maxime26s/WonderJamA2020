using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retourner_carte : MonoBehaviour
{
    public Text texto;
    public Image im1;
    public Image im2;
    public Image im3;
    public Image a_but;
    public Sprite carte1;
    public Sprite carte2;
    public Sprite carte3;
    public Sprite carte4;
    public Sprite carte5;
    public Sprite carte6;
    public Sprite verso;
    public Sprite verso_selected;
    int i=0;
    int random1;
    int random2;
    int random3;
    int nbSprite = 12;
    List<Image> images = new List<Image>();
    List<Sprite> sprites= new List<Sprite>();
    List<int> randoms= new List<int>();
    bool neutre = true;
    bool over = false;
    bool aDown = false;
    // Start is called before the first frame update
    void Start()
    {
        images.Add(im1);
        images.Add(im2);
        images.Add(im3);

        sprites.Add(carte1);
        sprites.Add(carte1);
        sprites.Add(carte1);
        
        sprites.Add(carte2);
        sprites.Add(carte2);
        sprites.Add(carte2);
       
        sprites.Add(carte3);
        sprites.Add(carte3);
        
        sprites.Add(carte4);
        sprites.Add(carte4);
        
        sprites.Add(carte5);
        
        sprites.Add(carte6);

        
        for(int i =0; i<3; i++)
        {
            randoms.Add(Random.Range(0, nbSprite));
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("A"))
            aDown = false;

        if (!aDown)
        {
            if (Input.GetButton("A"))
            {
                aDown = true;
                images[i].sprite = sprites[randoms[i]];
                over = true;
                a_but.enabled = false;
                switch (randoms[i])
                {
                    case 0:
                    case 1:
                    case 2:
                        texto.text = "Du temps à été ajouté à votre compteur!";
                        GameManager.Instance.AjoutTemps(20);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        texto.text = "Du temps à été enlevé à votre compteur!";
                        GameManager.Instance.PerteTemps(15);
                        break;
                    case 6:
                    case 7:
                        texto.text = "vous passez par dessus le prochain ennemi!";
                        GameManager.Instance.SkipEnemy();
                        break;
                    case 8:
                    case 9:
                        texto.text = "vous reculez à la salle précédente du donjon!";
                        GameManager.Instance.ReculeCase();
                        break;
                    case 10:
                        texto.text = "vous passez directement au boss du donjon!";
                        GameManager.Instance.TpBoss();
                        break;
                    case 11:
                        texto.text = "vous retournez à la première salle du donjon!";
                        GameManager.Instance.TpStart();
                        break;
                    default:
                        break;
                }
                IEnumerator RetourMap()
                {
                    yield return new WaitForSeconds(2.5f);
                    GameManager.Instance.LoadMap();
                }
                StartCoroutine(RetourMap());
            }
            if (Input.GetAxis("Horizontal") > 0.9 && neutre && !over)
            {
                neutre = false;
                images[i].sprite = verso;
                i += 1;
                if (i > 2)
                {
                    i = 2;
                }
                images[i].sprite = verso_selected;
            }
            if (Input.GetAxis("Horizontal") < -0.9 && neutre && !over)
            {
                neutre = false;
                images[i].sprite = verso;
                i -= 1;
                if (i < 0)
                {
                    i = 0;
                }
                images[i].sprite = verso_selected;
            }
            if (Input.GetAxis("Horizontal") < 0.2 && Input.GetAxis("Horizontal") > -0.2)
            {
                neutre = true;

            }
        }
    }
}
