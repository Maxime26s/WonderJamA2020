using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuelManager : MonoBehaviour
{

    public bool buttonPressed = false;
    bool doublePress = false;
    bool initialized = false;
    public string buttonPressedName = "";
    string lastSpell = "";
    float multDebuff = 1f;


    public Inventory inventory;
    public Timer timer;
    public List<string> currentSequence = new List<string>();

    public TextMeshProUGUI spellName;
    public TextMeshProUGUI spellDamage;
    public Image spellIcon, enemyElement;
    public List<Image> combo, spellChoice;
    public Sprite transparent;
    public Spell currentSpell = null;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        timer = GameManager.Instance.mapManager.timer.GetComponentInChildren<Timer>();
    }

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.LoadMap();
        }

        if (!initialized)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            if(enemy != null)
                OnPlayerCreated();
        }

        if (Input.GetAxisRaw("Horizontal") <= 0.2
            && Input.GetAxisRaw("Vertical") <= 0.2
            && Input.GetAxisRaw("Horizontal") >= -0.2
            && Input.GetAxisRaw("Vertical") >= -0.2
            && !Input.GetButtonDown("A")
            && !Input.GetButtonDown("B")
            && !Input.GetButtonDown("X")
            && !Input.GetButtonDown("Y"))
        {
            buttonPressed = false;
            buttonPressedName = "";
        }
        if (Input.GetAxisRaw("Horizontal") <= 0.2
        && Input.GetAxisRaw("Vertical") <= 0.2
        && Input.GetAxisRaw("Horizontal") >= -0.2
        && Input.GetAxisRaw("Vertical") >= -0.2
        && (buttonPressedName == ""))
        {
            buttonPressed = false;
            buttonPressedName = "";
        }
        else if (Input.GetAxisRaw("Horizontal") <= 0.2
        && Input.GetAxisRaw("Vertical") <= 0.2
        && Input.GetAxisRaw("Horizontal") >= -0.2
        && Input.GetAxisRaw("Vertical") >= -0.2)
        {
            if (buttonPressedName != "")
            {
                if (Input.GetButtonUp(buttonPressedName))
                {
                    buttonPressed = false;
                    buttonPressedName = "";
                }
            }
            else
            {
                buttonPressed = false;
                buttonPressedName = "";
            }
        }

        if (!buttonPressed)
        {
            //A
            if (Input.GetButtonDown("A"))
            {
                OnBoutonDown("A");
            }

            //B
            if (Input.GetButtonDown("B"))
            {
                OnBoutonDown("B");
            }

            //X
            if (Input.GetButtonDown("X"))
            {
                OnBoutonDown("X");
            }

            //Y
            if (Input.GetButtonDown("Y"))
            {
                OnBoutonDown("Y");
            }

            //joystick gauche
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                OnBoutonDown("LEFT");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick droite
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                OnBoutonDown("RIGHT");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick bas
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                OnBoutonDown("UP");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick haut
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                OnBoutonDown("DOWN");
                if (!buttonPressed)
                    buttonPressedName = "";
            }



            if (doublePress)
            {
                currentSequence.Clear();
                //Do Stuff
            }
            else if (currentSequence.Count > 0)
                VerifySequence();


        }

        //Dpad droite
        if (Input.GetAxis("Horizontal2") >= 0.7f)
        {
            if (inventory.spellCount >= 2)
                UpdateHeader(inventory.spells[1]);
        }

        //Dpad gauche
        if (Input.GetAxis("Horizontal2") <= -0.7f)
        {
            if (inventory.spellCount >= 4)
                UpdateHeader(inventory.spells[3]);
        }

        //Dpad haut
        if (Input.GetAxis("Vertical2") <= -0.7f)
        {
            UpdateHeader(inventory.spells[2]);
        }

        //Dpad bas
        if (Input.GetAxis("Vertical2") >= 0.7f)
        {
            if (inventory.spellCount >= 3)
                UpdateHeader(inventory.spells[0]);
        }

        doublePress = false;

    }

    public void VerifySequence()
    {
        bool allFailed = true;
        Spell spellCasted = null;

        //foreach (Spell spell in inventory.spells)
        //{
        bool failed = false;
        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (i < currentSpell.listeInputs.Count)
            {
                if (currentSequence[i] == currentSpell.listeInputs[i].name && !failed)
                {
                    combo[i].color = new Color32(100, 100, 100, 255);
                    if (i + 1 == currentSpell.listeInputs.Count)
                    {
                        spellCasted = currentSpell;
                        currentSequence.Clear();
                    }
                }
                else
                {
                    failed = true;
                }
            }
            else
                failed = true;

        }
        if (!failed)
            allFailed = false;
        //}

        if (allFailed)
        {
            currentSequence.Clear();
            for (int j = 0; j < combo.Count; j++)
                combo[j].color = new Color32(255, 255, 255, 255);
            timer.LoseTime(currentSpell.damage);
        }

        if (spellCasted != null)
        {
            //Do stuff
            float effectivBuff = 1f;
            Type enType = enemy.GetComponent<Enemy>().type;
            Type spType = spellCasted.type; 

            if(enType == Type.Fire && spType == Type.Water
                || enType == Type.Water && spType == Type.Air
                || enType == Type.Air && spType == Type.Earth
                || enType == Type.Earth && spType == Type.Fire)
            {
                effectivBuff = 1.5f;
            }
            else if (spType == Type.Fire && enType == Type.Water
                || spType == Type.Water && enType == Type.Air
                || spType == Type.Air && enType == Type.Earth
                || spType == Type.Earth && enType == Type.Fire)
            {
                effectivBuff = 0.5f;
            }

            if (lastSpell == spellCasted.name)
                multDebuff *= 0.7f;
            else
                multDebuff = 1f;

            lastSpell = spellCasted.name;
            Debug.Log(spellCasted.name + " casted");
            currentSequence.Clear();
            enemy.GetComponent<Timer>().LoseTime(spellCasted.damage * multDebuff * effectivBuff);
            IEnumerator wait()
            {
                yield return new WaitForSeconds(0.15f);
                for (int j = 0; j < combo.Count; j++)
                    combo[j].color = new Color32(255, 255, 255, 255);
            }
            StartCoroutine(wait());
        }
    }

    public void OnBoutonDown(string name)
    {
        if (buttonPressed)
            doublePress = true;
        else
            buttonPressedName = name;
        buttonPressed = true;
        currentSequence.Add(name);
    }


    public void UpdateHeader(Spell spell)
    {
        
        spellName.text = spell.name;
        spellDamage.text = "Damage: " + spell.damage;
        spellIcon.sprite = spell.sprite;
        spellIcon.material = spell.material;
        for (int i = 0; i < combo.Count; i++)
        {
            if (i >= spell.listeInputs.Count)
                combo[i].enabled = false;

            else
            {
                combo[i].enabled = true;
                combo[i].sprite = spell.listeInputs[i].sprite;
            }
        }
        currentSpell = spell;
    }

    public void OnPlayerCreated()
    {
        currentSequence.Clear();
        for (int i = 0; i < spellChoice.Count; i++)
        {
            spellChoice[i].enabled = false;
        }
        for (int i = 0; i < inventory.spells.Count; i++)
        {
            spellChoice[i].enabled = true;
            spellChoice[i].sprite = inventory.spells[i].sprite;
            spellChoice[i].material = inventory.spells[i].material;
        }
        UpdateHeader(inventory.spells[0]);
        if (enemy.GetComponent<Enemy>().type == Type.Air)
        {
            enemyElement.sprite = spellChoice[1].sprite;
            enemyElement.material = spellChoice[1].material;
        }
        if (enemy.GetComponent<Enemy>().type == Type.Fire)
        {
            enemyElement.sprite = spellChoice[2].sprite;
            enemyElement.material = spellChoice[2].material;
        }
        if (enemy.GetComponent<Enemy>().type == Type.Earth)
        {
            enemyElement.sprite = spellChoice[0].sprite;
            enemyElement.material = spellChoice[0].material;
        }
        if (enemy.GetComponent<Enemy>().type == Type.Water)
        {
            enemyElement.sprite = spellChoice[3].sprite;
            enemyElement.material = spellChoice[3].material;
        }
        //timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        initialized = true;
    }

    public void EndFight()
    {
        Debug.Log("FINI");
    }

}
