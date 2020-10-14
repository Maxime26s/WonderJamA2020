using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public List<Spell> spells = new List<Spell>();
    public int spellCount;
    public List<Spell> prefabs = new List<Spell>();
    public List<BoutonManette> boutons = new List<BoutonManette>();
    bool firstIt = true;

    // Start is called before the first frame update
    void Start()
    {
        spells.Clear();
        AddSpell("Vents violents");
        AddSpell("Eboulement");
        AddSpell("Vague de chaleur");
        AddSpell("Vague");
        firstIt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpell(string newSpell)
    {
        Spell added = null;
        for (int i = 0; i < prefabs.Count; i++)
            if (prefabs[i].name == newSpell)
                added = prefabs[i];

        added.listeInputs.Clear();

        RandomizeCombo(added);

        if (firstIt)
            spells.Add(added);

        for (int i = 0; i < spells.Count; i++)
            if (added.type == spells[i].type && added.damage >= spells[i].damage)
                spells[i] = added;
    }

    public void RandomizeCombo(Spell spell)
    {
        int longueur = 3;
        switch (spell.difficulty)
        {
            case 1:
                longueur = Random.Range(3, 4);
                break;
            case 2:
                longueur = Random.Range(4, 5);
                break;
            case 3:
                longueur = Random.Range(4, 6);
                break;
            case 4:
                longueur = Random.Range(5, 6);
                break;
            case 5:
                longueur = Random.Range(6, 7);
                break;
        }

        for (int i = 0; i < longueur; i++)
        {
            spell.listeInputs.Add(boutons[Random.Range(0, 7)]);
        }
    }
}
