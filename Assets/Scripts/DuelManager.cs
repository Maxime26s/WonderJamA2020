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
    bool over;

    public float arbitraryMultiplier;
    public Inventory inventory;
    public Timer timer;
    public List<string> currentSequence = new List<string>();

    public TextMeshProUGUI spellName;
    public TextMeshProUGUI spellDamage;
    public TextMeshProUGUI spellMult;
    public Image spellIcon, enemyElement;
    public List<Image> combo, spellChoice;
    public Sprite transparent;
    public Spell currentSpell = null;
    public GameObject enemy, smoke;
    public AnimOnly playerAnim;
    public List<ParticleSystem> particles;
    public List<AudioClip> particleSounds;
    public AudioClip hitSound;

    Input input;

    // Start is called before the first frame update
    void Start()
    {
        input = new Input();
        timer = GameManager.Instance.mapManager.timer.GetComponentInChildren<Timer>();
        MusicManager.Instance.FightMusic();
    }

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
                playerAnim = player.GetComponent<AnimOnly>();
            if (enemy != null && playerAnim != null)
                OnPlayerCreated();
        }

        if (Mathf.Abs(InputManager.Instance.x1) < 0.2
            && Mathf.Abs(InputManager.Instance.y1) < 0.2
            && !InputManager.Instance.a
            && !InputManager.Instance.b
            && !InputManager.Instance.x
            && !InputManager.Instance.y)
        {
            buttonPressed = false;
            buttonPressedName = "";
        }


        if (!buttonPressed && !over)
        {
            //A
            if (InputManager.Instance.a)
            {
                OnBoutonDown("A");
            }

            //B
            if (InputManager.Instance.b)
            {
                OnBoutonDown("B");
            }

            //X
            if (InputManager.Instance.x)
            {
                OnBoutonDown("X");
            }

            //Y
            if (InputManager.Instance.y)
            {
                OnBoutonDown("Y");
            }

            //joystick gauche
            if (InputManager.Instance.x1 < -0.85)
            {
                OnBoutonDown("LEFT");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick droite
            if (InputManager.Instance.x1 > 0.85)
            {
                OnBoutonDown("RIGHT");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick bas
            if (InputManager.Instance.y1 > 0.85)
            {
                OnBoutonDown("UP");
                if (!buttonPressed)
                    buttonPressedName = "";
            }

            //joystick haut
            if (InputManager.Instance.y1 < -0.85)
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
        if (InputManager.Instance.x2 > 0.85)
        {
                UpdateHeader(inventory.spells[1]);
        }

        //Dpad gauche
        if (InputManager.Instance.x2 < -0.85)
        {
                UpdateHeader(inventory.spells[3]);
        }

        //Dpad haut
        if (InputManager.Instance.y2 < -0.85)
        {
            UpdateHeader(inventory.spells[0]);
        }

        //Dpad bas
        if (InputManager.Instance.y2 > 0.85)
        {
            UpdateHeader(inventory.spells[2]);
        }

        doublePress = false;
    }

    public void VerifySequence()
    {
        bool allFailed = true;
        Spell spellCasted = null;

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

        if (allFailed)
        {
            currentSequence.Clear();
            for (int j = 0; j < combo.Count; j++)
                combo[j].color = new Color32(255, 255, 255, 255);
            timer.RemoveTime((int)currentSpell.damage, (int)((currentSpell.damage - (int)currentSpell.damage) * 100f));
        }

        if (spellCasted != null)
        {
            StartCoroutine(playerAnim.AttackAnim());
            //Do stuff
            float effectivBuff = 1f;
            Type enType = enemy.GetComponent<Enemy>().type;
            Type spType = spellCasted.type;

            if(spType == Type.Water)
            {
                Instantiate(particles[0], new Vector3(enemy.transform.position.x, enemy.transform.position.y, 10), Quaternion.identity);
                this.GetComponent<AudioSource>().clip = particleSounds[0];
            }
            else if(spType == Type.Air)
            {
                Instantiate(particles[1], new Vector3(enemy.transform.position.x, enemy.transform.position.y, 10), Quaternion.identity);
                this.GetComponent<AudioSource>().clip = particleSounds[1];
            }
            else if(spType == Type.Earth)
            {
                Instantiate(particles[2], new Vector3(enemy.transform.position.x, enemy.transform.position.y, 10), Quaternion.identity);
                this.GetComponent<AudioSource>().clip = particleSounds[2];
            }
            else if(spType == Type.Fire)
            {
                Instantiate(particles[3], new Vector3(enemy.transform.position.x, enemy.transform.position.y, 10), Quaternion.identity);
                this.GetComponent<AudioSource>().clip = particleSounds[3];
            }
            this.GetComponent<AudioSource>().Play();

            if (enType == Type.Fire && spType == Type.Water
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
                multDebuff *= 0.75f;
            else
                multDebuff = 1f;

            lastSpell = spellCasted.name;
            currentSequence.Clear();
            float temp = spellCasted.damage * multDebuff * 0.75f * effectivBuff;
            enemy.GetComponent<Timer>().RemoveTime((int)temp, (int)((temp - (int)temp) * 100f));

            float tempSpellMult = multDebuff * effectivBuff;
            if (tempSpellMult >= 1f)
                spellMult.color = new Color32(79, 240, 122, 255);
            else if(tempSpellMult < 1f)
                spellMult.color = new Color32(255, 54, 74, 255); ;
            spellMult.text = string.Format("x{0:0.00}", tempSpellMult);

            IEnumerator Red()
            {
                for (float j = 1f; j >= 0f; j -= 0.01f + Time.deltaTime)
                {
                    Color c = enemy.GetComponent<SpriteRenderer>().color;
                    c.g = j;
                    c.b = j;
                    enemy.GetComponent<SpriteRenderer>().color = c;
                    yield return null;
                }
                GameObject.FindWithTag("Hit").GetComponent<AudioSource>().clip = hitSound;
                GameObject.FindWithTag("Hit").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(0.3f);
                for (float j = 0f; j <= 1f; j += 0.01f + Time.deltaTime)
                {
                    Color c = enemy.GetComponent<SpriteRenderer>().color;
                    c.g = j;
                    c.b = j;
                    enemy.GetComponent<SpriteRenderer>().color = c;
                    yield return null;
                }
            }
            StartCoroutine(Red());
            

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
        spellDamage.text = "Degats: " + spell.damage;
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

        float templol;
        if (lastSpell == currentSpell.name)
            templol = multDebuff;
        else
            templol = 1;
        float tempSpellMult = templol * TypeMult();
        if (tempSpellMult >= 1f)
            spellMult.color = new Color32(79, 240, 122, 255);
        else if (tempSpellMult < 1f)
            spellMult.color = new Color32(255, 54, 74, 255); ;
        spellMult.text = string.Format("x{0:0.00}", tempSpellMult);
    }

    public void OnPlayerCreated()
    {
        inventory = Inventory.Instance;
        Debug.Log(inventory);
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
        UpdateEnemyElement();
        initialized = true;
    }

    public void UpdateEnemyElement()
    {
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
    }

    public void EndFight()
    {
        MusicManager.Instance.MapMusic();
        enemy.SetActive(false);
        over = true;
        Instantiate(smoke, new Vector3(enemy.transform.position.x, enemy.transform.position.y, 10), Quaternion.identity);
        this.GetComponent<AudioSource>().clip = particleSounds[4];
        this.GetComponent<AudioSource>().Play();
        StartCoroutine("ChangeMap");
    }

    IEnumerator ChangeMap()
    {
        yield return new WaitForSeconds(1f);

        GameManager.Instance.LoadMap();

        yield return null;
    }

    float TypeMult()
    {
        Type enType = enemy.GetComponent<Enemy>().type;
        Type spType = currentSpell.type;

        if (enType == Type.Fire && spType == Type.Water
            || enType == Type.Water && spType == Type.Air
            || enType == Type.Air && spType == Type.Earth
            || enType == Type.Earth && spType == Type.Fire)
        {
            return 1.5f;
        }
        else if (spType == Type.Fire && enType == Type.Water
            || spType == Type.Water && enType == Type.Air
            || spType == Type.Air && enType == Type.Earth
            || spType == Type.Earth && enType == Type.Fire)
        {
            return 0.5f;
        }
        else
        {
            return 1f;
        }
    }
}
