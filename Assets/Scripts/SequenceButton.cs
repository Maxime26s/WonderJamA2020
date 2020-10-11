using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceButton : MonoBehaviour
{
    public SpriteRenderer spriteButton;
    public Sprite aButton;//1
    public Sprite bButton;//2
    public Sprite xButton;//3
    public Sprite yButton;//4
    private Sprite[] butseq = new Sprite[4];
    public Sprite[] entreeUser = new Sprite[4];
    private bool ok = true;//seq
    private bool ok1 = false;//user
    private bool ok2 = false;
    private bool ok3 = false;
    private bool ok4 = false;
    private string[] nomButton = {"A","B","X","Y"};

    public int compteur=0;
    public List<int> nombre = new List<int>();

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int a = Random.Range(0, 3);
            nombre[i] = a;

            if (nombre[i] == 0) {
                butseq[i] = aButton;
            }
            else if (nombre[i] == 1)
            {
                butseq[i] = bButton;
            }
            else if (nombre[i] == 2)
            {
                butseq[i] = xButton;
            }
            else
            {
                butseq[i] = yButton;
            }
        }
        Debug.Log(nombre[0]);
        Debug.Log(nombre[1]);
        Debug.Log(nombre[2]);
        Debug.Log(nombre[3]);
    }
    void Update()
    {
        

       if (ok)
        {
            spriteButton.GetComponent<SpriteRenderer>().enabled = true;
            ok = false;
            switch (compteur)
            {
                case 0:
                    StartCoroutine(WaitAndPrint(2,spriteButton,butseq[compteur]));
                    break;
                case 1:
                    StartCoroutine(WaitAndPrint1(2,spriteButton,butseq[compteur],butseq[compteur-1]));
                    break;
                case 2:
                    StartCoroutine(WaitAndPrint2(2, spriteButton, butseq[2],butseq[1],butseq[0]));
                    break;
                case 3:
                    StartCoroutine(WaitAndPrint3(2, spriteButton, butseq[3],butseq[2], butseq[1],butseq[0]));
                    break;
                default:
                    Application.LoadLevel(2);
                    break;
            }
        }
        if (ok1)
        {
            ok2 = false;
            ok3 = false;
            ok4 = false;
            if (compteur == 3)
            {
                CheckButton3();
            }
            if(compteur == 2)
            {
                CheckButton2();
            }
            if(compteur == 1)
            {
                CheckButton1();
            } 
            if(compteur == 0)
            {
                CheckButton(); 
            }
             
        }
    }
    public IEnumerator WaitAndPrint(float f,SpriteRenderer sr1,Sprite sprite)
    {
        sr1.sprite = sprite;
        yield return new WaitForSeconds(f);
        ok1 = true;
        sr1.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("hello");
    }
    public IEnumerator WaitAndPrint1(float f, SpriteRenderer sr1,Sprite sprite,Sprite sprite1)
    {
        spriteButton.GetComponent<SpriteRenderer>().enabled = true;
        sr1.sprite = sprite1;
        yield return new WaitForSeconds(f);
        spriteButton.GetComponent<SpriteRenderer>().enabled = false;
        spriteButton.GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(WaitAndPrint(2,sr1,sprite));
        Debug.Log("hi");
    }
    public IEnumerator WaitAndPrint2(float f, SpriteRenderer sr1,Sprite sprite, Sprite sprite1,Sprite sprite2)
    {
        yield return new WaitForSeconds(f);
        spriteButton.GetComponent<SpriteRenderer>().enabled = false;
        spriteButton.GetComponent<SpriteRenderer>().enabled = true;
        sr1.sprite = sprite2;
        StartCoroutine(WaitAndPrint1(2, sr1, sprite,sprite1));
    }
    public IEnumerator WaitAndPrint3(float f,SpriteRenderer sr1,Sprite sprite, Sprite sprite1, Sprite sprite2,Sprite sprite3)
    {
        yield return new WaitForSeconds(f);
        spriteButton.GetComponent<SpriteRenderer>().enabled = false;
        spriteButton.GetComponent<SpriteRenderer>().enabled = true;
        sr1.sprite = sprite3;
        StartCoroutine(WaitAndPrint2(2, sr1, sprite, sprite1,sprite2));
    }
    public void CheckButton()
    {
        if (Input.GetButtonDown("A"))
        {
            if (nomButton[nombre[compteur]] == "A")
            {
                compteur++;
                ok1 = false;
                ok = true;
                StartCoroutine(WaitAndPrint(0.2f,spriteButton,entreeUser[nombre[compteur]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("B"))
        {
            if (nomButton[nombre[compteur]] == "B")
            {
                compteur++;
                ok1 = false;
                ok = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("X"))
        {
            if (nomButton[nombre[compteur]] == "X")
            {
                compteur++;
                ok1 = false;
                ok = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur]])); 
            }
            else
            {
                compteur = 0;
            }

        } else if (Input.GetButtonDown("Y"))
        {
            if (nomButton[nombre[compteur]] == "Y")
            {
                compteur++;
                ok1 = false;
                ok = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        }
    public void CheckButton1()
        {
        if (Input.GetButtonDown("A"))
        {
            if (nomButton[nombre[compteur - 1]] == "A")
            {
                ok2 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-1]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("B"))
        {
            if (nomButton[nombre[compteur - 1]] == "B")
            {
                ok2 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-1]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("X"))
        {
            if (nomButton[nombre[compteur - 1]] == "X")
            {
                ok2 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-1]]));
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("Y"))
        {
            if (nomButton[nombre[compteur - 1]] == "Y")
            {
                ok2 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-1]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        if (ok2)
        {
            CheckButton();
        }
        
        }
    public void CheckButton2()
    {
        if (Input.GetButtonDown("A"))
        {
            if (nomButton[nombre[compteur - 2]] == "A")
            {
                ok3 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-2]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("B"))
        {
            if (nomButton[nombre[compteur-2]] == "B")
            {
                ok3 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-2]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("X"))
        {
            if (nomButton[nombre[compteur - 2]] == "X")
            {
                ok3 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-2]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("Y"))
        {
            if (nomButton[nombre[compteur - 2]] == "Y")
            {
                ok3 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-2]]));
            }
            else
            {
                compteur = 0;
            }
        }

        if (ok3)
        {
            CheckButton1();
        }
    }
        public void CheckButton3()
    {
        if (Input.GetButtonDown("A"))
        {
            if (nomButton[nombre[compteur - 3]] == "A")
            {
                ok4 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-3]]));
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("B"))
        {
            if (nomButton[nombre[compteur - 3]] == "B")
            {
                ok4 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-3]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("X"))
        {
            if (nomButton[nombre[compteur - 3]] == "X")
            {
                ok4 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-3]])); 
            }
            else
            {
                compteur = 0;
            }

        }
        else if (Input.GetButtonDown("Y"))
        {
            if (nomButton[nombre[compteur - 3]] == "Y")
            {
                ok4 = true;
                StartCoroutine(WaitAndPrint(0.2f, spriteButton, entreeUser[nombre[compteur-3]])); 
            }
            else
            {
                compteur = 0;
            }
        }

        if (ok4)
        {
            CheckButton2();
        }
    }
}
