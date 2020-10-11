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
    public GameObject reward, particle;
    public List<Spell> loots = new List<Spell>();
    public Image spellSprite;
    public TextMeshProUGUI spellText;

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
                    particle.SetActive(true);
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Spell given = loots[Random.Range(0, 15)];
                    spellText.gameObject.SetActive(true);
                    spellSprite.gameObject.SetActive(true);
                    spellText.text = given.name;
                    spellSprite.sprite = given.sprite;
                    Inventory.Instance.AddSpell(given.name);
                    reward.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    GameManager.Instance.LoadMap();
                }
                StartCoroutine(WaitAndLeave());
            }

            float x = Input.GetAxisRaw("Horizontal");
            if(x > 0.4  && (right || first))
            {
                first = false;
                amount--;
                right = !right;
                transform.eulerAngles = new Vector3(0,0, Random.Range(5, 25));
                float scale = Random.Range(0.9f, 1.2f);
                transform.localScale = new Vector3(scale, scale, 1);
            } else if (x < -0.4 && (!right || first))
            {
                first = false;
                amount--;
                right = !right;
                transform.eulerAngles = new Vector3(0, 0, Random.Range(-25, -5));
                float scale = Random.Range(0.9f, 1.2f);
                transform.localScale = new Vector3(scale, scale, 1);
            }
        }
    }
}
