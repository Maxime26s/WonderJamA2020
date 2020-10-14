using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{
    bool right = false;
    bool first = true;
    int amount;
    public Vector2 range;
    bool stop = false;
    public GameObject reward, guide, particleDestroy, particleShake;
    public List<Spell> loots = new List<Spell>();
    public Image spellSprite;
    public TextMeshProUGUI spellText;
    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        amount = Random.Range((int)range.x, (int)range.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (amount == 0)
            {
                stop = true;
                IEnumerator WaitAndLeave()
                {
                    Instantiate(particleDestroy, transform.position, Quaternion.identity);
                    GetComponent<AudioSource>().clip = explosion;
                    GetComponent<AudioSource>().volume = 0.1f;
                    GetComponent<AudioSource>().Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Spell given = loots[Random.Range(0, 15)];
                    spellText.gameObject.SetActive(true);
                    spellSprite.gameObject.SetActive(true);
                    spellText.text = given.name + "\n" + "Dmg: " + given.damage;
                    spellSprite.sprite = given.sprite;
                    spellSprite.material = given.material;
                    Inventory.Instance.AddSpell(given.name);
                    guide.SetActive(false);
                    reward.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    GameManager.Instance.LoadMap();
                }
                StartCoroutine(WaitAndLeave());
            }

            float x = InputManager.Instance.x1;
            if(x > 0.4 && (right || first))
            {
                first = false;
                amount--;
                right = !right;
                transform.eulerAngles = new Vector3(0,0, Random.Range(5, 25));
                float scale = Random.Range(0.8f, 1.1f);
                transform.localScale = new Vector3(scale, scale, 1);
                Instantiate(particleShake, transform.position, Quaternion.identity);
                GetComponent<AudioSource>().Play();
            } else if (x < -0.4 && (!right || first))
            {
                first = false;
                amount--;
                right = !right;
                transform.eulerAngles = new Vector3(0, 0, Random.Range(-25, -5));
                float scale = Random.Range(0.8f, 1.1f);
                transform.localScale = new Vector3(scale, scale, 1);
                GetComponent<AudioSource>().Play();
                Instantiate(particleShake, transform.position, Quaternion.identity);
            }
        }
    }
}
